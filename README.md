# TinRoll
A stackoverflow clone built with F# + Giraffe for the backend and React for the front end. Right now it's very feature bare. You can ask text only questions and can view them in a list. 


# Running Locally

DB Setup: 

1. Install Sql Server
2. Right now TinRoll is defaulted to use localdb instance. 
3. Run src/api/TinRoll.Migrations/updateDatabase.ps1 script to create local database.
4. If that fails, try logging into sql server instance through SSMS and creating the `TinRollDb` manually then rerunning the script. Some versions of LocalDb have a bug around creating databases.

API Setup:

1. Download Visual Studio Code
2. Open up the API folder in Visual Studio Code.
3. You should be prompted to install some extensions, the ionide plugin allowing F# support.
4. Edit the API to your heart's content.
5. You can either run the project from Visual Studio Code, or un the src/api/run.ps1 script to launch the API.

UI Setup:

1. In src/ui folder, run `npm install`.
2. Run `npm run start`
3. Navigate browser to `localhost:8080` to access the UI.

# Articles

Here are the blog posts that have been written over TinRoll as an app.

[Getting Started: Part 1](https://medium.com/p/blazor-ef-core-a-simple-web-app-part-1-3c54380cf69a?source=email-89d87dcc9e73--writer.postDistributed&sk=d959c0e17fb0f15e15eb58a47c88155c)

[Getting Started: Part 2](https://medium.com/@morgankenyon/blazor-ef-core-a-simple-web-app-part-2-705d2e8e5813)

[TinRoll #3: Building Out the API Layer](https://medium.com/@morgankenyon/tinroll-3-building-out-the-api-layer-e5a404d5fd64)

[TinRoll #4: Creating a Generic Repository](https://medium.com/@morgankenyon/tinroll-4-creating-a-generic-repository-9846c72e11ec)

# RoadMap

Things that might get done if time permits. 

* Answers
* User accounts (some type of basic authentication)
* Stats (voting, accepted answers, reputation)
* Comments
* Admin Features (Flagging
* Editing Posts
* Notifications
* Tags
* Badges
* Search
* wysiwyg editor
* user profile
* Multi Tenant
* ???
