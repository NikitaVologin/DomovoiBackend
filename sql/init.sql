CREATE TABLE IF NOT EXISTS public."Announcement"
(
    "Id" uuid NOT NULL,
    "Description" text COLLATE pg_catalog."default",
    "ConnectionType" text COLLATE pg_catalog."default",
    "CounterAgentId" uuid,
    CONSTRAINT "PK_Announcement" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Announcement_CounterAgents_CounterAgentId" FOREIGN KEY ("CounterAgentId")
        REFERENCES public."CounterAgents" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Announcement"
    OWNER to postgres;

CREATE INDEX IF NOT EXISTS "IX_Announcement_CounterAgentId"
    ON public."Announcement" USING btree
    ("CounterAgentId" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Announcement_Id"
    ON public."Announcement" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;
	
CREATE TABLE IF NOT EXISTS public."ApartmentHouses"
(
    "Id" uuid NOT NULL,
    "BuildingYear" integer NOT NULL,
    "Type" text COLLATE pg_catalog."default",
    "CeilingHeight" double precision NOT NULL,
    "IsGas" boolean NOT NULL,
    "HaveGarbageChute" boolean NOT NULL,
    "IsSecurity" boolean NOT NULL,
    "HaveParking" boolean NOT NULL,
    "Infrastructures" text[] COLLATE pg_catalog."default" NOT NULL,
    "Landscaping" text[] COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_ApartmentHouses" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."ApartmentHouses"
    OWNER to postgres;

CREATE TABLE IF NOT EXISTS public."Area"
(
    "Id" uuid NOT NULL,
    "Electricity" boolean NOT NULL,
    "WaterSupply" boolean NOT NULL,
    "Gas" boolean NOT NULL,
    "Sewage" boolean NOT NULL,
    CONSTRAINT "PK_Area" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Area_Reality_Id" FOREIGN KEY ("Id")
        REFERENCES public."Reality" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Area"
    OWNER to postgres;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Area_Id"
    ON public."Area" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS public."Bathrooms"
(
    "Id" uuid NOT NULL,
    "Type" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_Bathrooms" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Bathrooms"
    OWNER to postgres;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Bathrooms_Id"
    ON public."Bathrooms" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS public."Buildings"
(
    "Id" uuid NOT NULL,
    "Class" text COLLATE pg_catalog."default",
    "BuildingYear" integer NOT NULL,
    "CenterName" text COLLATE pg_catalog."default",
    "HaveParking" boolean NOT NULL,
    "IsEquipment" boolean NOT NULL,
    CONSTRAINT "PK_Buildings" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Buildings"
    OWNER to postgres;
	
CREATE UNIQUE INDEX IF NOT EXISTS "IX_Buildings_Id"
    ON public."Buildings" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS public."CommercialBuilding"
(
    "Id" uuid NOT NULL,
    "FloorsCount" integer NOT NULL,
    "Entry" text COLLATE pg_catalog."default",
    "IsUse" boolean NOT NULL,
    "Access" text COLLATE pg_catalog."default",
    "BuildingId" uuid,
    CONSTRAINT "PK_CommercialBuilding" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_CommercialBuilding_Buildings_BuildingId" FOREIGN KEY ("BuildingId")
        REFERENCES public."Buildings" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_CommercialBuilding_Reality_Id" FOREIGN KEY ("Id")
        REFERENCES public."Reality" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."CommercialBuilding"
    OWNER to postgres;

CREATE INDEX IF NOT EXISTS "IX_CommercialBuilding_BuildingId"
    ON public."CommercialBuilding" USING btree
    ("BuildingId" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_CommercialBuilding_Id"
    ON public."CommercialBuilding" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS public."Deals"
(
    "Id" uuid NOT NULL,
    "Price" double precision NOT NULL,
    CONSTRAINT "PK_Deals" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Deals_Announcement_Id" FOREIGN KEY ("Id")
        REFERENCES public."Announcement" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Deals"
    OWNER to postgres;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Deals_Id"
    ON public."Deals" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS public."Flats"
(
    "Id" uuid NOT NULL,
    "IsFresh" boolean NOT NULL,
    "RoomsCount" integer NOT NULL,
    "IsRepaired" boolean NOT NULL,
    "KitchenArea" double precision NOT NULL,
    "BalconyType" text COLLATE pg_catalog."default",
    "ViewFromBalcony" text COLLATE pg_catalog."default",
    "BuildingId" uuid,
    CONSTRAINT "PK_Flats" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Flats_ApartmentHouses_BuildingId" FOREIGN KEY ("BuildingId")
        REFERENCES public."ApartmentHouses" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
    CONSTRAINT "FK_Flats_LivingBuilding_Id" FOREIGN KEY ("Id")
        REFERENCES public."LivingBuilding" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Flats"
    OWNER to postgres;

CREATE INDEX IF NOT EXISTS "IX_Flats_BuildingId"
    ON public."Flats" USING btree
    ("BuildingId" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Flats_Id"
    ON public."Flats" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;
	
-- Table: public.Garage

-- DROP TABLE IF EXISTS public."Garage";

CREATE TABLE IF NOT EXISTS public."Garage"
(
    "Id" uuid NOT NULL,
    "State" text COLLATE pg_catalog."default",
    "GKSName" text COLLATE pg_catalog."default",
    "Access" boolean NOT NULL,
    "Security" boolean NOT NULL,
    "Electricity" boolean NOT NULL,
    "Heating" boolean NOT NULL,
    "WaterSupply" boolean NOT NULL,
    "Infrastructure" boolean NOT NULL,
    CONSTRAINT "PK_Garage" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Garage_Reality_Id" FOREIGN KEY ("Id")
        REFERENCES public."Reality" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Garage"
    OWNER to postgres;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Garage_Id"
    ON public."Garage" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS public."HousePart"
(
    "Id" uuid NOT NULL,
    "Part" integer NOT NULL,
    "HouseId" uuid,
    CONSTRAINT "PK_HousePart" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_HousePart_Houses_HouseId" FOREIGN KEY ("HouseId")
        REFERENCES public."Houses" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_HousePart_LivingBuilding_Id" FOREIGN KEY ("Id")
        REFERENCES public."LivingBuilding" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."HousePart"
    OWNER to postgres;

CREATE INDEX IF NOT EXISTS "IX_HousePart_HouseId"
    ON public."HousePart" USING btree
    ("HouseId" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_HousePart_Id"
    ON public."HousePart" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;
	
-- Table: public.Houses

-- DROP TABLE IF EXISTS public."Houses";

CREATE TABLE IF NOT EXISTS public."Houses"
(
    "Id" uuid NOT NULL,
    "BuildYear" integer NOT NULL,
    "RoomsCount" integer NOT NULL,
    "IsRenovated" boolean NOT NULL,
    "IsHeating" boolean NOT NULL,
    "IsAccess" boolean NOT NULL,
    "IsInfrastructure" boolean NOT NULL,
    "IsLandscaping" boolean NOT NULL,
    "BathroomId" uuid,
    "HouseAreaId" uuid,
    CONSTRAINT "PK_Houses" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Houses_Area_HouseAreaId" FOREIGN KEY ("HouseAreaId")
        REFERENCES public."Area" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_Houses_Bathrooms_BathroomId" FOREIGN KEY ("BathroomId")
        REFERENCES public."Bathrooms" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_Houses_LivingBuilding_Id" FOREIGN KEY ("Id")
        REFERENCES public."LivingBuilding" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Houses"
    OWNER to postgres;

CREATE INDEX IF NOT EXISTS "IX_Houses_BathroomId"
    ON public."Houses" USING btree
    ("BathroomId" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE INDEX IF NOT EXISTS "IX_Houses_HouseAreaId"
    ON public."Houses" USING btree
    ("HouseAreaId" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Houses_Id"
    ON public."Houses" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS public."LegalCounterAgent"
(
    "Id" uuid NOT NULL,
    "Name" text COLLATE pg_catalog."default",
    "Tin" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_LegalCounterAgent" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_LegalCounterAgent_CounterAgents_Id" FOREIGN KEY ("Id")
        REFERENCES public."CounterAgents" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."LegalCounterAgent"
    OWNER to postgres;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_LegalCounterAgent_Id"
    ON public."LegalCounterAgent" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS public."LivingBuilding"
(
    "Id" uuid NOT NULL,
    "Floor" integer NOT NULL,
    "FloorsCount" integer NOT NULL,
    CONSTRAINT "PK_LivingBuilding" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_LivingBuilding_Reality_Id" FOREIGN KEY ("Id")
        REFERENCES public."Reality" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."LivingBuilding"
    OWNER to postgres;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_LivingBuilding_Id"
    ON public."LivingBuilding" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;
	
-- Table: public.Office

-- DROP TABLE IF EXISTS public."Office";

CREATE TABLE IF NOT EXISTS public."Office"
(
    "Id" uuid NOT NULL,
    "Name" text COLLATE pg_catalog."default",
    "RoomsCount" integer NOT NULL,
    "Floor" integer NOT NULL,
    CONSTRAINT "PK_Office" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Office_CommercialBuilding_Id" FOREIGN KEY ("Id")
        REFERENCES public."CommercialBuilding" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Office"
    OWNER to postgres;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Office_Id"
    ON public."Office" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS public."PhysicalCounterAgent"
(
    "Id" uuid NOT NULL,
    "FIO" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_PhysicalCounterAgent" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PhysicalCounterAgent_CounterAgents_Id" FOREIGN KEY ("Id")
        REFERENCES public."CounterAgents" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."PhysicalCounterAgent"
    OWNER to postgres;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_PhysicalCounterAgent_Id"
    ON public."PhysicalCounterAgent" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;
	
-- Table: public.Productions

-- DROP TABLE IF EXISTS public."Productions";

CREATE TABLE IF NOT EXISTS public."Productions"
(
    "Id" uuid NOT NULL,
    "Infrastructure" boolean NOT NULL,
    "RoomsQuantity" integer NOT NULL,
    CONSTRAINT "PK_Productions" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Productions_CommercialBuilding_Id" FOREIGN KEY ("Id")
        REFERENCES public."CommercialBuilding" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Productions"
    OWNER to postgres;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Productions_Id"
    ON public."Productions" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;
	
-- Table: public.Reality

-- DROP TABLE IF EXISTS public."Reality";

CREATE TABLE IF NOT EXISTS public."Reality"
(
    "Id" uuid NOT NULL,
    "Area" double precision NOT NULL,
    "Type" text COLLATE pg_catalog."default",
    "Address" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_Reality" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Reality_Announcement_Id" FOREIGN KEY ("Id")
        REFERENCES public."Announcement" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Reality"
    OWNER to postgres;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Reality_Id"
    ON public."Reality" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS public."Rent"
(
    "Id" uuid NOT NULL,
    CONSTRAINT "PK_Rent" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Rent_Deals_Id" FOREIGN KEY ("Id")
        REFERENCES public."Deals" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Rent"
    OWNER to postgres;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Rent_Id"
    ON public."Rent" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS public."RentConditions"
(
    "Id" uuid NOT NULL,
    "Period" text COLLATE pg_catalog."default",
    "Deposit" double precision NOT NULL,
    "CommunalPays" double precision NOT NULL,
    "Prepay" double precision NOT NULL,
    "Facilities" text COLLATE pg_catalog."default",
    "WithKids" boolean NOT NULL,
    "WithAnimals" boolean NOT NULL,
    "CanSmoke" boolean NOT NULL,
    CONSTRAINT "PK_RentConditions" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_RentConditions_Rent_Id" FOREIGN KEY ("Id")
        REFERENCES public."Rent" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."RentConditions"
    OWNER to postgres;
	
-- Table: public.Reviews

-- DROP TABLE IF EXISTS public."Reviews";

CREATE TABLE IF NOT EXISTS public."Reviews"
(
    "Id" uuid NOT NULL,
    "DestinationId" uuid NOT NULL,
    "AuthorId" uuid NOT NULL,
    "Rate" integer NOT NULL,
    "Header" text COLLATE pg_catalog."default" NOT NULL,
    "Text" text COLLATE pg_catalog."default" NOT NULL,
    "ReviewDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_Reviews" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Reviews_CounterAgents_AuthorId" FOREIGN KEY ("AuthorId")
        REFERENCES public."CounterAgents" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
    CONSTRAINT "FK_Reviews_CounterAgents_DestinationId" FOREIGN KEY ("DestinationId")
        REFERENCES public."CounterAgents" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Reviews"
    OWNER to postgres;

CREATE INDEX IF NOT EXISTS "IX_Reviews_AuthorId"
    ON public."Reviews" USING btree
    ("AuthorId" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE INDEX IF NOT EXISTS "IX_Reviews_DestinationId"
    ON public."Reviews" USING btree
    ("DestinationId" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Reviews_Id"
    ON public."Reviews" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;


CREATE TABLE IF NOT EXISTS public."Rooms"
(
    "Id" uuid NOT NULL,
    "NeighboursCount" integer NOT NULL,
    "FlatId" uuid,
    CONSTRAINT "PK_Rooms" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Rooms_Flats_FlatId" FOREIGN KEY ("FlatId")
        REFERENCES public."Flats" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_Rooms_LivingBuilding_Id" FOREIGN KEY ("Id")
        REFERENCES public."LivingBuilding" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Rooms"
    OWNER to postgres;

CREATE INDEX IF NOT EXISTS "IX_Rooms_FlatId"
    ON public."Rooms" USING btree
    ("FlatId" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Rooms_Id"
    ON public."Rooms" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;
	
-- Table: public.Sell

-- DROP TABLE IF EXISTS public."Sell";

CREATE TABLE IF NOT EXISTS public."Sell"
(
    "Id" uuid NOT NULL,
    CONSTRAINT "PK_Sell" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Sell_Deals_Id" FOREIGN KEY ("Id")
        REFERENCES public."Deals" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Sell"
    OWNER to postgres;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Sell_Id"
    ON public."Sell" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;

CREATE TABLE IF NOT EXISTS public."SellConditions"
(
    "Id" uuid NOT NULL,
    "Type" text COLLATE pg_catalog."default",
    "YearInOwn" integer NOT NULL,
    "OwnersCount" integer NOT NULL,
    "PrescribersCount" integer NOT NULL,
    "HaveChildOwners" boolean NOT NULL,
    "HaveChildPrescribers" boolean NOT NULL,
    CONSTRAINT "PK_SellConditions" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_SellConditions_Sell_Id" FOREIGN KEY ("Id")
        REFERENCES public."Sell" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."SellConditions"
    OWNER to postgres;

CREATE TABLE IF NOT EXISTS public."Warehouses"
(
    "Id" uuid NOT NULL,
    "Infrastructure" boolean NOT NULL,
    CONSTRAINT "PK_Warehouses" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Warehouses_CommercialBuilding_Id" FOREIGN KEY ("Id")
        REFERENCES public."CommercialBuilding" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Warehouses"
    OWNER to postgres;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Warehouses_Id"
    ON public."Warehouses" USING btree
    ("Id" ASC NULLS LAST)
    TABLESPACE pg_default;
	
INSERT INTO public."CounterAgents"(
	"Id", "ContactNumber", "Email", "Password")
	VALUES ('184ff091-9769-452e-a23b-c89743e9d370', '+1 (111) 111 11-11', '1_physical@mail.ru', '123');
INSERT INTO public."PhysicalCounterAgent"(
	"Id", "FIO")
	VALUES ('184ff091-9769-452e-a23b-c89743e9d370', 'Pudger Pudge Ridge');

INSERT INTO public."CounterAgents"(
	"Id", "ContactNumber", "Email", "Password")
	VALUES ('825eb2a0-6d5c-440b-b76a-46bf259bfa95', '+2 (222) 222 22-22', '2_physical@mail.ru', '123');
INSERT INTO public."PhysicalCounterAgent"(
	"Id", "FIO")
	VALUES ('825eb2a0-6d5c-440b-b76a-46bf259bfa95', 'Гигрыч Пудж Раджарович');

INSERT INTO public."CounterAgents"(
	"Id", "ContactNumber", "Email", "Password")
	VALUES ('ee7dd076-74dd-4da4-b011-d714df033e8e', '+3 (333) 333 33-33', '3_physical@mail.ru', '123');
INSERT INTO public."PhysicalCounterAgent"(
	"Id", "FIO")
	VALUES ('ee7dd076-74dd-4da4-b011-d714df033e8e', 'Дадарыданду Парикашон Мыхдарыч');

INSERT INTO public."CounterAgents"(
	"Id", "ContactNumber", "Email", "Password")
	VALUES ('496dd6b5-230e-4fa8-8296-71967f8bcaa2', 'Вор Карманник Удовлетворёныч');
INSERT INTO public."PhysicalCounterAgent"(
	"Id", "FIO")
	VALUES ('496dd6b5-230e-4fa8-8296-71967f8bcaa2', '+5 (555) 555 55-55', '5_physical@mail.ru', '123');
	
INSERT INTO public."CounterAgents"(
	"Id", "ContactNumber", "Email", "Password")
	VALUES ('496dd6b5-230e-4fa8-8296-71967f8bcaa2', '+5 (555) 555 55-55', '5_physical@mail.ru', '123');
INSERT INTO public."PhysicalCounterAgent"(
	"Id", "FIO")
	VALUES ('496dd6b5-230e-4fa8-8296-71967f8bcaa2', 'ЯБольной НаГолову Человек');
	
INSERT INTO public."CounterAgents"(
	"Id", "ContactNumber", "Email", "Password")
	VALUES ('57d959ac-5e88-4d9c-a10e-43b7beefe94c', '11-11-11', '1_legal@mail.ru', '123');
INSERT INTO public."LegalCounterAgent"(
	"Id", "Name", "Tin")
	VALUES ('57d959ac-5e88-4d9c-a10e-43b7beefe94c', 'ООО Первая Компания', '1');
	
INSERT INTO public."CounterAgents"(
	"Id", "ContactNumber", "Email", "Password")
	VALUES ('63d5e6c5-6c84-4372-a270-877b80029ed3', '22-22-22', '2_legal@mail.ru', '123');
INSERT INTO public."LegalCounterAgent"(
	"Id", "Name", "Tin")
	VALUES ('63d5e6c5-6c84-4372-a270-877b80029ed3', 'ООО Вторая Компания', '2');
	
INSERT INTO public."CounterAgents"(
	"Id", "ContactNumber", "Email", "Password")
	VALUES ('91cc2266-bb2f-4002-9c46-893ce84acc4a', '33-33-33', '3_legal@mail.ru', '123');
INSERT INTO public."LegalCounterAgent"(
	"Id", "Name", "Tin")
	VALUES ('91cc2266-bb2f-4002-9c46-893ce84acc4a', 'ООО Третья Компания', '3');
	
INSERT INTO public."CounterAgents"(
	"Id", "ContactNumber", "Email", "Password")
	VALUES ('e7b8976e-ba22-4fe5-a9b9-42d9e41fe948', '44-44-44', '4_legal@mail.ru', '123');
INSERT INTO public."LegalCounterAgent"(
	"Id", "Name", "Tin")
	VALUES ('e7b8976e-ba22-4fe5-a9b9-42d9e41fe948', 'ООО Четвёртая Компания', '4');
	
INSERT INTO public."CounterAgents"(
	"Id", "ContactNumber", "Email", "Password")
	VALUES ('9a141242-199a-4642-8b08-ae86f90dd60e', '55-55-55', '5_legal@mail.ru', '123');
INSERT INTO public."LegalCounterAgent"(
	"Id", "Name", "Tin")
	VALUES ('9a141242-199a-4642-8b08-ae86f90dd60e', 'ООО Пятая Компания', '5');