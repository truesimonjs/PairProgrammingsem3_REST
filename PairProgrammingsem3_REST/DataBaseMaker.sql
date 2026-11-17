drop table if exists [dbo].MusicRecords

create table [MusicRecords]
(
[id] integer Primary KEY,
[title] nvarchar (255),
[artist] nvarchar(255),
[durationInSeconds] integer,
[publicationYear] integer,

)