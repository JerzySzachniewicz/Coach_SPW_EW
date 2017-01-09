

CREATE TABLE Users
(
    UsserId INT NOT NULL,
    Nick VARCHAR(20) UNIQUE,
    Email VARCHAR(50) UNIQUE,
    Password VARCHAR(50),
    DateOfBirth DATE,
    isTrainer BIT,
    Coach INT,
    TrainingPlan INT,
    PRIMARY KEY(UsserId)
);

CREATE TABLE Results
(
    ResultId INT NOT NULL,
    Users_Id INT,
    Height FLOAT,
    Weights FLOAT,
    BodyFat FLOAT,
    ChestCircumference FLOAT,
    BicepsCircumference FLOAT,
    Waist FLOAT,
    ThighCircumference FLOAT,
    PRIMARY KEY(ResultId)
);

CREATE TABLE TrainingPlan
(
    PlanId INT NOT NULL,
    Type INT,
    Level INT,
    Coach INT NOT NULL,
    PRIMARY KEY(PlanId)
);

CREATE TABLE Exercise
(
    ExerciseId INT NOT NULL,
    Name VARCHAR(50),
    PRIMARY KEY(ExerciseId)
);

CREATE TABLE TrainingType
(
    TypeId INT NOT NULL,
    Name VARCHAR(50),
    DescriptionOfTraining VARCHAR(255),
    PRIMARY KEY(TypeId)
);

CREATE TABLE TrainingResult
(
    ResultId INT NOT NULL,
    UserId INT NOT NULL,
    SessionId INT,
    Data DATE,
    Setisfaction INT,
    PRIMARY KEY(ResultId)
);

CREATE TABLE TrainingSession
(
    SessionId INT NOT NULL,
    DayOfTraining INT,
    PRIMARY KEY(SessionId)
);

CREATE TABLE TrainingSessionsInPlan
(
    PlanId INT NOT NULL,
    SessionId INT NOT NULL,
    PRIMARY KEY(PlanId, SessionId)
);

CREATE TABLE ExercisesInSession
(
    SessionId INT NOT NULL,
    ExerciseId INT NOT NULL,
    Series INT,
    Repeats INT,
    Description VARCHAR(255),
    PRIMARY KEY(SessionId, ExerciseId)
);



ALTER TABLE Results
    ADD    FOREIGN KEY (Users_Id)
    REFERENCES Users(UsserId)
;
    
ALTER TABLE Users
    ADD    FOREIGN KEY (Coach)
    REFERENCES Users(UsserId)
;
    
ALTER TABLE Users
    ADD    FOREIGN KEY (TrainingPlan)
    REFERENCES TrainingPlan(PlanId)
;
    
ALTER TABLE TrainingPlan
    ADD    FOREIGN KEY (Type)
    REFERENCES TrainingType(TypeId)
;
    
ALTER TABLE TrainingPlan
    ADD    FOREIGN KEY (PlanId)
    REFERENCES TrainingSessionsInPlan(PlanId)
;
    
ALTER TABLE TrainingSessionsInPlan 
    ADD    FOREIGN KEY (SessionId)
    REFERENCES TrainingSession(SessionId)
;
    
ALTER TABLE ExercisesInSession
    ADD    FOREIGN KEY (ExerciseId)
    REFERENCES Exercise(ExerciseId)
;
    
ALTER TABLE ExercisesInSession
    ADD    FOREIGN KEY (SessionId)
    REFERENCES TrainingSession(SessionId)
;
    
ALTER TABLE TrainingResult
    ADD    FOREIGN KEY (SessionId)
    REFERENCES TrainingSession(SessionId)
;
    
ALTER TABLE TrainingPlan
    ADD    FOREIGN KEY (Coach)
    REFERENCES Users(UsserId)
;
    
ALTER TABLE TrainingResult
    ADD    FOREIGN KEY (UserId)
    REFERENCES Users(UsserId)
;
    



