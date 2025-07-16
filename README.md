
##  Prerequisites

| Tool           | Version / Link                                                                                  |
| -------------- | ----------------------------------------------------------------------------------------------- |
| .NET SDK       | `9.0` — [Download](https://dotnet.microsoft.com/download/dotnet/9.0)                             |
| Git            | [https://git-scm.com/](https://git-scm.com/)                                                     |
| Postman        | (optional) [Postman](https://www.postman.com/)                                                  |
| Java           | `15+` — [Download](https://www.oracle.com/java/technologies/javase/jdk15-archive-downloads.html) |
| Apache Maven   | [https://maven.apache.org/](https://maven.apache.org/)                                           |

---

##  Repository Structure

```text
AbcloudzTestTask/
├── UsersApi/                         # .NET Web API project
├── Tests/
│   ├── Postman/                      # Postman collection & environment
│   │   └── postman_collection.json
│   └── Java/                         # RestAssured tests
│       ├── pom.xml
│       └── src/
│           └── test/
│               └── java/
│                   └── UsersApiTest.java
└── README.md
```

---

##  1. Running the API

```bash
# 1. Clone the repo
git clone https://github.com/SvyatoslavSvan/AbcloudzTestTask.git
cd AbcloudzTestTask/UsersApi

# 2. Launch the API (both HTTP and HTTPS)
dotnet run --urls "https://localhost:7255;http://localhost:5272"
```

- **HTTPS**: https://localhost:7255  
- **HTTP**:  http://localhost:5272  

---

##  2. Running Postman Tests

### Option 1: Postman Cloud Workspace

 [Open in browser](https://www.postman.com/solar-meadow-468000/workspace/abcloudztesttask)

### Option 2: Newman (CLI)

```bash
cd AbcloudzTestTask/Tests/Postman
newman run postman_collection.json -k
```

>  `-k` — skip SSL certificate validation (self-signed)

### Option 3: Postman Desktop App

1. Open Postman → **Import**  
2. Select **File** → upload `Tests/Postman/postman_collection.json`  
3. Run the collection from **Collections**  

---

##  3. Running Java + RestAssured Tests

```bash
# Ensure Java 15+ and Maven are on your PATH
cd AbcloudzTestTask/Tests/Java
mvn test
```

---

