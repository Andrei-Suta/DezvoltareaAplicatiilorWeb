# Movie API


Pentru autentificare am folosit ASP.NET Core Identity, avand doua tipuri de useri: Administrator si User. Am adaugat autorizare pe endpoint-uri pentru ambele roluri.
In baza de date am:
-Intre Rating si Movie relatie one to one(UNIQUE constraint pe FK in Rating)
-Intre Movie si Actor relatie many to many(tabelul MA cu PK compusa)
-Intre Director si Movie relatie one to one(am adaugat constraint pentru a considera aceasta relatie one to one, in contextul aplicatiei mele)
-Intre Genre si Movie relatie one to many

Am folosit metode linq, repository pattern si unit of work.
