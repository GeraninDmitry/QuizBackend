DROP TABLE IF EXISTS temp_quiz;

CREATE TEMPORARY TABLE temp_quiz
(
    QuizId   uuid PRIMARY KEY,
    UserId   text,
    UserName varchar(256),
    Type     integer,
    Theme    integer,
    Title    text,
    Image    text,
    Text     text
);

insert into temp_quiz
select q."QuizId",
       q."UserId",
       u."UserName",
       q."Type",
       q."Theme",
       q."Title",
       q."Image",
       q."Text"
from "Quiz" q
         join "AspNetUsers" u on q."UserId" = u."Id"
where (q."Type" & @type) = q."Type"
  and q."Status" = 2
  and q."Application" = @applicationType
  and q."Language" = @languageType
  and (q."Theme" & @theme) = q."Theme"
  and (@isNewQuiz is null or
       @userId not in (select "QuizMark"."UserId"
                       from "QuizMark"
                       where "QuizMark"."Type" = 1
                         and "QuizMark"."UserId" = @userId
                         and "QuizMark"."QuizId" = q."QuizId"))
  and (@isSubscribed is null or
       @userId in (select "UserFollower"."UserId"
                   from "UserFollower"
                   where "UserFollower"."FollowedUserId" = q."UserId"
                     and "UserFollower"."UserId" = @userId
                     and "UserFollower"."IsFollowing" = true))
ORDER BY random() LIMIT 1;

SELECT *
FROM temp_quiz;

select qt."QuizTagId",
       qt."Text",
       qt."IsTrue"
from "QuizTag" qt
         join temp_quiz q on qt."QuizId" = q.QuizId;

select "UserName" as UserName,
       "Id"       as UserId,
       ui."Image" as UserImage
from "AspNetUsers" u
         left join "UserImage" ui on u."Id" = ui."UserId"
         join temp_quiz q on u."Id" = q.UserId;

select "IsLiked"    as IsLiked,
       "IsDisliked" as IsDisliked
from "QuizRespect" qr
         join temp_quiz q on qr."QuizId" = q.QuizId
where qr."UserId" = @userId;