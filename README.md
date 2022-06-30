## API Bliss


### Configure:
This project was made using Visual Studio 2022 and .NET 6 and MySQL as databases.

##### Follow these steps:

 1 - Check if MySQL Service is running;
 
 2 - Open the file **"appsettings.json"** and change those lines:

     { "DefaultConnection":"Server=localhost;DataBase=**NAME_DATA_BASE**;Uid=**USER**;Pwd=DATA_BASE_PASSWORD"}

3 - Change **Server**, **DataBase**, **Uid** and **Pwd** inserting your data;



##### Opening and executing the API:

1 - Open the project with Visual Studio and click on **"Tools>Command Line>Developer Command Prompt"**;

2 - Execute the command **"cd ApiBliss"** and **"dotnet ef database update"**;

3 - Building the application clicking on **"Debug > Start Debugging"** or "F5".