DROP TABLE IF EXISTS temp_quiz;

CREATE TEMPORARY TABLE temp_quiz
(
    RowNumber   integer,
    QuizId      uuid PRIMARY KEY,
    UserId      text,
    UserName    varchar(256),
    Type        integer,
    Theme       integer,
    Application integer,
    Status      integer,
    Title       text,
    Image       text,
    Text        text
);

insert into temp_quiz
select *
from (select ROW_NUMBER() OVER (ORDER BY q."CreatedOn" DESC) AS RowNumber,
             q."QuizId",
             q."UserId",
             u."UserName",
             q."Type",
             q."Theme",
             q."Application",
             q."Status",
             q."Title",
             q."Image",
             q."Text"
      from "Quiz" q
               join "AspNetUsers" u on q."UserId" = u."Id"
      where q."UserId" = @userId
        and q."Application" = @applicationType
        and (@isAuthorized = true or q."Status" = 2)) as quizzes
where RowNumber = @quizIndex;

SELECT *
FROM temp_quiz;