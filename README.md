# Contact Management Solution

## Project Architecture

The project has been built using the FastEndpoints library as an alternative to Minimal APIs / controllers.

I opted for this due to the comparable performance to Minimal APIs and rich functionality out-of-the-box, making it quick to build with.

Additionally, it lends itself well to a vertical slice architecture, which the project is also utilising. This allows for easily maintainable, self-contained feature slices

## Database / Data Seeding

As suggested, and for project simplicity, the solution is using an in-memory database. 

Due to this, there is no need for any migrations, etc., and the 'Funds' will be automatically seeded on startup within the `InitialisationExtensions.cs` file.

## Testing

For testing, the project can simply be run via IIS Express directly through your IDE.

I have included a Postman collection that contains all the necessary requests: `ContactManagement.postman_collection.json`.

This can be imported directly into Postman for immediate testing.