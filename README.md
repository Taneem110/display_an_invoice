# Invoice Display Application

A full-stack ASP.NET Core web application for displaying and managing invoices with a modern UI and RESTful API.

## Features

✅ **Fixed & Working**
- Invoice display UI with HTML/CSS/JavaScript
- RESTful API endpoints with error handling
- SQL Server database integration
- Swagger API documentation
- CORS enabled for cross-origin requests
- Entity Framework Core ORM

## Tech Stack

- **Backend:** ASP.NET Core 8.0
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **API Documentation:** Swagger/OpenAPI
- **Frontend:** HTML5, CSS3, JavaScript

## Quick Start

### Prerequisites
- .NET 8.0 SDK
- SQL Server Express
- Git

### Installation

1. **Clone the Repository**
```bash
git clone <your-repo-url>
cd display_an_invoice
```

2. **Install Dependencies**
```bash
dotnet restore
```

3. **Set Up Database**
```bash
# Install EF Tools globally (if not already installed)
dotnet tool install --global dotnet-ef

# Create and apply migrations
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4. **Run the Application**
```bash
dotnet run
```

5. **Access the Application**
- **UI:** `http://localhost:5000`
- **Swagger API:** `http://localhost:5000/swagger`

## API Endpoints

### Get Invoice Items
```http
GET /api/invoice
```

**Response:**
```json
{
  "items": [
    {
      "itemID": 1,
      "invoiceID": 1,
      "name": "Widget A",
      "price": 19.99
    }
  ]
}
```

### Get All Data
```http
GET /api/data
```

## Project Structure

```
├── Program.cs                 # App startup configuration
├── appsettings.json          # Configuration
├── BuggyApp.csproj           # Project file
├── InvoiceContext.cs         # EF Core DbContext
├── Controllers/
│   ├── InvoiceController.cs  # Invoice API
│   └── APIController.cs      # Data API
└── wwwroot/
    ├── index.html            # UI
    ├── script.js             # Client-side logic
    └── styles.css            # Styling
```

## Bugs Fixed

| Issue | Status | Fix |
|-------|--------|-----|
| NullReferenceException in InvoiceController | ✅ Fixed | Added database context injection |
| Null items list | ✅ Fixed | Initialize from database |
| JavaScript typos (fetc, jsoon, prce) | ✅ Fixed | Corrected all function names |
| HTML unclosed tag | ✅ Fixed | Properly closed title tag |
| SQL syntax error (REFRENCES) | ✅ Fixed | Corrected to REFERENCES |

## Database Schema

```sql
CREATE TABLE Invoices (
    InvoiceID INT PRIMARY KEY,
    CustomerName VARCHAR(100)
);

CREATE TABLE InvoiceItems (
    ItemID INT PRIMARY KEY,
    InvoiceID INT,
    Name VARCHAR(100),
    Price DECIMAL(10,2),
    FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID)
);

-- Sample Data
INSERT INTO Invoices (InvoiceID, CustomerName) VALUES (1, 'John Doe');
INSERT INTO InvoiceItems (ItemID, InvoiceID, Name, Price) 
VALUES (1, 1, 'Widget A', 19.99);
```

## Configuration

### SQL Server Connection
Edit `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=invoicedb;Trusted_Connection=true;Encrypt=false;"
  }
}
```

## Deployment Options

### Azure App Service
```bash
# Publish
dotnet publish -c Release -o ./publish

# Deploy using Azure CLI
az webapp deployment source config-zip --resource-group myGroup --name myApp --src publish.zip
```

### Heroku
```bash
# Create Procfile (Windows)
echo "web: dotnet BuggyApp.dll" > Procfile

# Deploy
heroku create
git push heroku main
```

## Troubleshooting

### Database Connection Error
- Ensure SQL Server is running
- Verify connection string
- Check database exists

### Port Already in Use
```bash
dotnet run --urls "https://localhost:5002"
```

### Swagger Not Loading
- Ensure packages are installed: `dotnet restore`
- Check console for errors

## Testing

```bash
# Test API
curl https://localhost:5001/api/invoice
curl https://localhost:5001/swagger
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit changes
4. Push to the branch
5. Create a Pull Request

## License

This project is open source and available under the MIT License.

## Support

For issues and questions, please open an GitHub issue.

---

**Status:** ✅ Production Ready
**Last Updated:** April 14, 2026
