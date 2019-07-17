# LoanManagement ReadMe

## Overview
A new WebAPI and a SPA have been created to  enable the users to apply for topups and new loans.

### Features Implemented
#### WebAPI
* EFCore Code first approach is used to create the database
* Used Repository pattern to fetch the data 
* UserLoanController exposes the required RESTFul API to fetch and manipulate the user loans
* Created Unit tests for this controller usinf xUnit and Moq
#### UI
* Created using React Redux
* Implmented Container Presentational component pattern whereever possible
* Handled Server errors and are displayed on the screen
* Tried to create the UI that matches with the woreframes provided

### Pending Items
WebAPI
* Unit tests for all the controller methods and Reposiroty
UI 
* Refactor the components
* Refine UI
* Implement Apply for Topup and Apply for New Loan buttons
* Create unit tests for Functional, container components, Reducers and Actions.

## Project Structure

No. | Project | Description
--|--------|------------
1|LoanManagement|WebAPI project with MSSQL LocalDB created using .NetCore v2.2
2|LoanManagement.Test| Unit tests for WEBAPI Controller
3|LoanManagement\ClientApp|SPA created using React,Redux

## Tools Used

- VS2019 
- Visual Studio Code
- Postman
