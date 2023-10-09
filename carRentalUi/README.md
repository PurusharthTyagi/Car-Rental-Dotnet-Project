Backend - MVc ,Entity Framework, web Api
Frontend - Angular
Database - SQL Server

1) First run the backend by extracting Backend file
    a) Backend contains ("Backend.sln") run it in Visual Studio
    b) Rebuild 
    c) Run " update-database " command 
    d) In SQL server a database will be created of name "CarRental"
    e) We have used seeding technique for the admin so ,
               - you can simply signUp for a user
		- Admin Credentials = {
                                       Email : - tester@test.com
		                       Password : - Markmark
                                       }  

        
2) Then run the frontend by extracting Frontend file carRentalUI
    a) run carRentalUi in VScode
    b) make sure you are in the location where angular is intialized ("which you will be by default")
    c) then use the command "ng serve -o"
    d) run command npm install to install module