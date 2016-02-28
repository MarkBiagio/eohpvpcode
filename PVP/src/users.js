
db.getCollection('user').insert([{
	LoginName: "mark@eoh.co.za",
	Name: "mark",
	IsActive: true,
	Roles: [ { Description: "User" }, { Description: "Administrator"}]
},

{
	LoginName: "adriaan@eoh.co.za",
	Name: "adriaan",
	IsActive: true,
	Roles: [ { Description: "User" }, { Description: "Administrator"}]
},

{
	LoginName: "denzil@eoh.co.za",
	Name: "denzil",
	IsActive: true,
	Roles: [ { Description: "User" } ]
},

{
	LoginName: "deon@eoh.co.za",
	Name: "deon",
	IsActive: false,
	Roles: [ { Description: "User" } ]
}]);
