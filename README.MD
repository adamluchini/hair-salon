# _Hair Salon Database_

#### By _**Adam Luchini**_

## Description

_This application allows an owner of a hair salon to update their employee and client list. It's capable of add/removing/updating the names of stylists. For each stylist, the user can input clients specific to that stylist and add/remove/update their names too._


## Setup/Installation Requirements

* _Clone this repository_
* _Open Windows PowerShell_
* _Type sqlcmd -S "(localdb)\mssqllocaldb" into PowerShell to prompt SQLCMD_
* _Set up the hair salon database by typing the following into SQLCMD_
  * _CREATE DATABASE hairsalon;_
  * _GO_
  * _USE hairsalon;_
  * _GO_
  * _CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));_
  * _CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255) stylist_id INT);_
  * _GO_
  * _quit_
* _Navigate to project folder_
* _Run dnu restore in the command line_
* _Run dnx kestrel in the command line_
* _Open Google Chrome to localhost:5004_

## Technologies Used
* _Microsoft SQL Server Management Studio 2016_
* _C#_
* _Nancy 1.3.0_
* _Razor 1.3.0_
* _xunit 2.1.0_

### Legal

Copyright (c) 2016 **_Adam Luchini_**

This software is licensed under the MIT license.
