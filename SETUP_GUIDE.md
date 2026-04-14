# Invoice Display Application - Setup Guide

## Prerequisites
- **.NET 8.0 SDK** - Download from https://dotnet.microsoft.com/download
- **SQL Server Express** - Download from https://www.microsoft.com/en-us/sql-server/sql-server-downloads
- **Git** - Download from https://git-scm.com

## Installation & Setup

### Step 1: Install .NET 8.0 SDK
```powershell
# Download and run the installer from: https://dotnet.microsoft.com/download
# Or use Windows Package Manager:
winget install Microsoft.DotNet.SDK.8
```

### Step 2: Install SQL Server Express
```
Download and install from: https://www.microsoft.com/en-us/sql-server/sql-server-downloads
Keep default settings, note the instance name (usually SQLEXPRESS)
```

### Step 3: Configure Connection String
Edit `appsettings.json` if needed:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=invoicedb;Trusted_Connection=true;Encrypt=false;"
  }
}
```

### Step 4: Create and Apply Migrations
```powershell
cd "c:\Users\tanee\Desktop\display_an_invoice (2)"

# Install Entity Framework Tools
dotnet tool install --global dotnet-ef

# Create initial migration
dotnet ef migrations add InitialCreate

# Apply migration to database
dotnet ef database update
```

### Step 5: Run the Application
```powershell
dotnet run
```

The application will be available at: `https://localhost:5001`

### Step 6: Access the Application
- **UI (Invoice Display):** https://localhost:5001
- **Swagger API Documentation:** https://localhost:5001/swagger
- **API Endpoint:** https://localhost:5001/api/invoice

## Project Structure
```
display_an_invoice/
├── Program.cs                 # Application startup configuration
├── appsettings.json          # Configuration file
├── BuggyApp.csproj           # Project file
├── InvoiceContext.cs         # Database context
├── InvoiceController.cs      # Invoice API endpoint
├── APIController.cs          # Data API endpoint
├── index.html                # Frontend UI
├── script.js                 # Frontend scripts
├── styles.css                # Frontend styles
└── init.sql                  # SQL initialization script
```

## Bugs Fixed
1. ✅ `InvoiceController.cs` - Removed NullReferenceException
2. ✅ `APIController.cs` - Added proper error handling
3. ✅ `script.js` - Fixed typos (DOMContentLoade, fetc, jsoon, prce, eror)
4. ✅ `index.html` - Fixed unclosed title tag
5. ✅ `init.sql` - Fixed REFRENCES typo

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
```

## Deployment

### Deploy to Azure App Service
```powershell
# Publish the application
dotnet publish -c Release -o ./publish

# Create Azure App Service (if needed)
az appservice plan create --name InvoicePlan --resource-group myGroup --sku B1
az webapp create --resource-group myGroup --plan InvoicePlan --name invoiceapp --runtime "DOTNET|8.0"

# Deploy
az webapp deployment source config-zip --resource-group myGroup --name invoiceapp --src publish.zip
```

## Troubleshooting

### Port already in use
```powershell
dotnet run --urls "https://localhost:5002"
```

### Database connection error
- Check SQL Server is running
- Verify connection string in appsettings.json
- Ensure database 'invoicedb' exists

### Swagger UI not loading
- Ensure you're accessing `/swagger` on the correct port
- Check that Swashbuckle packages are installed

## Support
For more information, visit:
- https://learn.microsoft.com/en-us/dotnet/
- https://learn.microsoft.com/en-us/ef/core/
- https://swagger.io/
