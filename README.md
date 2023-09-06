# Voting System

The Voting System is a web application that enables users to participate in votes on various topics. This system is designed for internal use, providing a platform for conducting votes and determining their results.

## Features

- **User Registration**: Users can create accounts to participate in votes.
- **User Authentication**: Secure login system to verify user identities.
- **Vote Participation**: Registered users can vote on available topics.
- **Real-time Results**: Users can view real-time vote results.

## Technologies Used

- **Programming Language**: C#
- **Web Framework**: ASP.NET MVC Core 6
- **Database**: SQL Server
- **Frontend**: HTML, CSS, JavaScript, Razor Views

## Usage Guide

Follow these steps to set up and run the Voting System locally:

1. **Clone the Repository**: Clone this repository to your local machine.

2. **Set Up the Database**: Create a SQL Server database and update the connection string in the `appsettings.json` file.
3. **Apply Migrations**: Run the following commands to add migrations and apply them to the database:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Run the Application**: Open the solution in Visual Studio or your preferred development environment. Build and run the application. 

6. **Access the Application**: Open a web browser and navigate to `http://localhost:port` (replace `port` with the actual port number).

7. **Register and Log In**: Create a user account or use the provided sample accounts to log in.

8. **Participate in Votes**: Explore available votes and cast your votes.

9. **View Real-time Results**: Observe the real-time results as votes are cast.

## Sample Data

The application comes with sample data for testing purposes. You can customize and extend the sample data as needed.


## Contact

For any questions or inquiries, please contact me -  [Mohammed Abduldaim](mailto:moh.daim996@gmail.com).
