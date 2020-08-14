<h2> Before integrating make changes in</h2>
<ol>
<li>Appseting.json</li>
<li>Appsetting.Development.json</li>
</ol>

<h3>Appsetting.json</h3>
<ol>
<li>Databse Server Setup</li>
<hr/>
<p>
"ConnectionStrings": 
{
    "DevConnection": "Server=(LocalDB)\\MSSQLLocalDB;Database=SRM;Trusted_Connection=True;MultipleActiveResultSets=True;"
  },
</p>
 <p>
 set your servername insted of <i>(LocalDB)\\MSSQLLocalDB<i> 
 </p>
 
 <li>Mail Server Setup</li>
 <hr/>
 <p>
 "EmailConfiguration": {
    "From": "yourmail@gmail.com",
    "SmtpServer": "smtp.gmail.com",
    "Port": 465,
    "Username": "yourmail@gmail.com",
    "Password": ""
  },
 </p>
 <p>
 add your mail
 and go to your "manage your google  account" and in 'Security Section'
 turn on 'Less secure app access'.
 
 After this all mail will be sent through this mail
 
 </p>
 </ol>
 
 
 <h3>Appsetting.Development.json</h3>
 
 Make All Above changes here also.
