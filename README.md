# Game Zone

Game Zone is a CRUD (Create, Read, Update, Delete) MVC application developed using .NET and Entity Framework Core. It allows users to manage a collection of games with features for image upload, validation, and more.

## Features
- Create, Read, Update, and Delete games
- Image upload with custom validation (max size and allowed extensions)
- Services for context communication
- Responsive user interface
- SweetAlert2 for interactive alerts
- Select2 for enhanced dropdowns

## Technologies Used
- .NET MVC
- Entity Framework Core
- Bootstrap (for responsive design)
- Custom Attributes for Validation
- SweetAlert2
- Select2

## Getting Started

### Prerequisites
- .NET SDK installed
- SQL Server (or any compatible database)

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/mahmoudiab152/gamezone.git
   ```
2. Navigate to the project directory:
   ```bash
   cd game-zone
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Update database:
   ```bash
   dotnet ef database update
   ```
5. Run the application:
   ```bash
   dotnet run
   ```

## Usage
1. Navigate to `https://localhost:44315` in your browser.
2. Use the interface to add, view, update, or delete games.
3. Upload game images with the specified validation rules.
4. Enjoy interactive alerts with SweetAlert2.
5. Utilize Select2 for improved dropdown selections.

## Custom Validation Attributes
- **Max Image Size:** Limits the maximum file size for uploaded images.
- **Allowed Extensions:** Restricts the file types that can be uploaded (e.g., .jpg, .png).

## License
This project is licensed under the MIT License.

## Contact
For any inquiries, please contact [mahmouddiab152@gmail.com].

