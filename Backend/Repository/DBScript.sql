CREATE TABLE BusinessUnits (
    BusinessUnitID INT PRIMARY KEY AUTO_INCREMENT,
    BusinessUnitName VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE ExperienceYears (
    ExperienceID INT PRIMARY KEY AUTO_INCREMENT,
    ExperienceDescription VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Qualifications (
    QualificationID INT PRIMARY KEY AUTO_INCREMENT,
    QualificationName VARCHAR(50) NOT NULL UNIQUE
);


CREATE TABLE JobPosts (
    PostID INT PRIMARY KEY AUTO_INCREMENT,
    PostName VARCHAR(255) NOT NULL,
    JobDescription TEXT NOT NULL,
    BusinessUnitID INT NOT NULL,
    ManagerName VARCHAR(255) NOT NULL,
    ManagerEmail VARCHAR(255) NOT NULL,
    ExperienceID INT NOT NULL,
    QualificationID INT NOT NULL,
    DriversLicenseRequired CHAR(1) NOT NULL CHECK (DriversLicenseRequired IN ('Y', 'N')),
    OpeningDate DATE NOT NULL,
    ClosingDate DATE NOT NULL,
    FOREIGN KEY (BusinessUnitID) REFERENCES BusinessUnits(BusinessUnitID),
    FOREIGN KEY (ExperienceID) REFERENCES ExperienceYears(ExperienceID),
    FOREIGN KEY (QualificationID) REFERENCES Qualifications(QualificationID)
);