DROP TABLE IF EXISTS temp_quiz;

CREATE TEMPORARY TABLE temp_quiz
(
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
select q."QuizId",
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
where q."QuizId" = @quizId
  and q."UserId" = @userId;

SELECT *
FROM temp_quiz;

select qt."QuizTagId",
       qt."Text",
       qt."IsTrue"
from "QuizTag" qt
         join temp_quiz q on qt."QuizId" = q.QuizId;