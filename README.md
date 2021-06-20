# PROJECT TYPE
Online booking system 

**COPYRIGHT INFO**
Due to the Covid 19 situation, the client shut down the business and never purchased the complete copyright. For this reason, the project is open sourced and available for education and any other purpose to the entire development community. As the only developer, I do not intend to work on this project anymore so happy coding.

**SHORT INTRODUCTION:**

This repository contains different projects whose purposes are:

* Online booking of local tours in the  city of Dubrovnik 
* Transfers and other services provided by tourist agency
* Web marketing and education about the city of Dubrovnik

The client goal is to develop 4 applications and one administration panel for all in order
as listed below:

* Dubrovnik Tours **COMPLITED** https://www.dubrovniktours.tours
* Cable Car Dubrovnik - **COMPLITED** https://www.cablecardubrovnik.com
* Mario Travel Admin  --> UNDER DEVELOPMENT
* Zagreb Tours (**IN LINE** - Waiting for Admin)
* Split Tours (**IN LINE** - Waiting for Admin and Zagreb Tours)
 
**We are using services from listed providers**:
* Domains: GoDaddy https://uk.godaddy.com/
* Cloud Hosting: Digital Ocean https://www.digitalocean.com/
* Mail Provider: MailGun https://www.mailgun.com/
* Payment Provider: AgentCash https://www.agentcash.com/

**DEVELOPMENT CONFIGURATIONS:**

Projects are configured for development under Docker containers as follows:
* Dubrovnik Tours running on **localhost//:5001**
* Cable Car Dubrovnik runing on **localhost//:5002**
* Zagreb Tours (Waiting for configuration - 5003 PRESERVED)
* Split Tours (Waiting for configuration - 5004 PRESERVED)
* MailServer running on **localhost//:5005**

Each web project is using preconfigured webpack module bundler for frontend development that is located in "Webpack" directorty
* All instructions how to use it can be found in ReadMe file under that directorty

**TECHNOLOGIES USED:** 

**.NET Core 3.1**

BackEnd
* C#
* PostgresSQL 
* Dapper & EntityFrameworkCore ORM

FrontEnd
* JavaScript
* EcmaScript 6
* jQuery
* CSS
* SASS
* Webpack 4