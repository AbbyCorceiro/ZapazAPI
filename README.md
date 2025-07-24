# ZapazAPI

<h3>About the API</h3>
<p>This API was created with learning purposes! It's just an example on how to use GET, POST, PUT, and DELETE on HTTPS request.</p>
<p>Also is intended to be a very basic example for a storage service interface for a "Sneakers Shop" like Adidas or Nike, or even a multibrand sneakers shop.</p>
<p>The API is using swagger for testing, and Entity Framework for the migrations to the database.</p>
<p>It has the Repository design pattern implemented with a service.</p>
<p>Is intended to implement authentication and authorization for securing the API</p>

# Documentation
<ul>
  <li>Added model and database context</li>
  <li>Installed neccesary packages for Swagger and Entity Framework</li>
  <li>Added GET, PUT, POST, and DELETE endpoints</li>
  <li>GET endpoints: Now you can search a sneaker by id, brand, model, color, size, genre (male, female, unisex), sport type, and availability trough SwaggerUI</li>
  <li>Added GET, POST, PUT and DELETE request for testing in the http file</li>
  <li>Added repository design pattern with a service (interface and implementation class)</li>
  <li>All endpoints are working with the repository service (GET, PUT, POST, DELETE)</li>
</ul>

# <h3>What's Next (To do):
  <ul>
    <li>[x] Add jwt in the appsettings.json</li>
    <li>[x] Configure jwt in program.cs</li>
    <li>[ ] Add User and UserDTO entities</li>
    <li>[ ] Program the password hashing for security</li>
    <li>[ ] Add authentication based on the credentials of the user</li>
    <li>[ ] Add authorization based on the user's rol (Admin, Guest)</li>
  </ul>
</h3>

# <h3>Objective:</h3>
The main objective of this exercise is to create an API REST example for a CRUD application
