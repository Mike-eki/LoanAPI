using LoanAPI.Context.IEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoanAPI.Context;

namespace LoanAPI.Models.Entities
{
    public class Person : IBaseEntity
    {
        //public int LoanId { get; set; }

        [Key]
        public int Id { get; set; }

        [InverseProperty("BorrowerPerson")]
        public ICollection<Loan> PersonLoans { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        public string Name { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public DateTime CreationTime { get; set; }
    }


public static class PersonDTOEndpoints
{
	public static void MapPersonDTOEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/PersonDTO", async (AplicationDbContext db) =>
        {
            return await db.PersonDTO.ToListAsync();
        })
        .WithName("GetAllPersonDTOs");

        routes.MapGet("/api/PersonDTO/{id}", async (int Id, AplicationDbContext db) =>
        {
            return await db.PersonDTO.FindAsync(Id)
                is PersonDTO model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetPersonDTOById");

        routes.MapPut("/api/PersonDTO/{id}", async (int Id, PersonDTO personDTO, AplicationDbContext db) =>
        {
            var foundModel = await db.PersonDTO.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })   
        .WithName("UpdatePersonDTO");

        routes.MapPost("/api/PersonDTO/", async (PersonDTO personDTO, AplicationDbContext db) =>
        {
            db.PersonDTO.Add(personDTO);
            await db.SaveChangesAsync();
            return Results.Created($"/PersonDTOs/{personDTO.Id}", personDTO);
        })
        .WithName("CreatePersonDTO");


        routes.MapDelete("/api/PersonDTO/{id}", async (int Id, AplicationDbContext db) =>
        {
            if (await db.PersonDTO.FindAsync(Id) is PersonDTO personDTO)
            {
                db.PersonDTO.Remove(personDTO);
                await db.SaveChangesAsync();
                return Results.Ok(personDTO);
            }

            return Results.NotFound();
        })
        .WithName("DeletePersonDTO");
    }
}}
