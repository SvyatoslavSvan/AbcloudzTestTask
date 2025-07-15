# AbcloudzTestTask

## Prerequisites

* .NET 9 SDK ([https://dotnet.microsoft.com/download/dotnet/9.0](https://dotnet.microsoft.com/download/dotnet/9.0))
* Git ([https://git-scm.com/](https://git-scm.com/))
* Postman (optional, for GUI tests)
* Java 15+ ([https://www.oracle.com/java/technologies/javase/jdk15-archive-downloads.html](https://www.oracle.com/java/technologies/javase/jdk15-archive-downloads.html))
* Apache Maven ([https://maven.apache.org/](https://maven.apache.org/))

## Repository Structure

```text
AbcloudzTestTask/
├── UsersApi/ .NET Web API project
├── Tests/
│ ├── Postman/ Postman collection & environment
│ │ └── postman_collection.json
│ └── Java/ RestAssured tests
│ ├── pom.xml
│ └── src/
│ └── test/
│ └── java/
│ └── UsersApiTest.java
└── README.md
```

## 1. Running the API

1. Clone the repo:
   git clone [https://github.com/SvyatoslavSvan/AbcloudzTestTask.git](https://github.com/SvyatoslavSvan/AbcloudzTestTask.git)
   cd AbcloudzTestTask
   cd UsersApi
2. Launch the API:
   dotnet run --urls "[https://localhost:7255;http://localhost:5272](https://localhost:7255;http://localhost:5272)"
3. The API will be available at:
   HTTPS: [https://localhost:7255](https://localhost:7255)
   HTTP:   [http://localhost:5272](http://localhost:5272)

## 2. Running Postman Tests

### Option 1: Postman Cloud Workspace

Open in your browser:
[https://www.postman.com/solar-meadow-468000/workspace/abcloudztesttask](https://www.postman.com/solar-meadow-468000/workspace/abcloudztesttask)

### Option 2: Newman (CLI)

1. Navigate to the Postman tests folder:
   cd AbcloudzTestTask/Tests/Postman
2. Run with Newman (allow self‑signed certs):
   newman run postman\_collection.json -k

### Option 3: Postman Desktop App

1. Open Postman.
2. Click Import (top‑left).
3. Select the File tab.
4. Drag‑and‑drop AbcloudzTestTask/Tests/Postman/postman\_collection.json (or click Upload Files).
5. Click Import.
6. Your collection appears under Collections — run it as usual.

## 3. Running Java + RestAssured Tests

1. Ensure Java 15+ and Maven are installed and on your PATH.
2. Navigate to the Java tests folder:
   cd AbcloudzTestTask/Tests/Java
3. Execute:
   mvn test
