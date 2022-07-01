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



##### TO UPDATE (FREQ-04: Share Screen):

The documentation of the API has a fundamental requirement to send an email.
It has not been fully resolved because Google's policy change does not allow non-secure apps to access the mail server anymore so after I talk with Tiago Braz it was made an implementation temporary that the email will be saved in a directory on the computer.