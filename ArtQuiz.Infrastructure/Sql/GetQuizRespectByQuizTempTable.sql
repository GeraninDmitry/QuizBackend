select "Quiz"."QuizId"        QuizId,
       Liked.LikedCount       LikedCount,
       Disliked.DislikedCount DislikedCount
from "Quiz"
         left join (select "QuizId" QuizId,
                           count(1) LikedCount
                    from "QuizRespect"
                    where "IsLiked" = true
                    group by "QuizId") as Liked on Liked.QuizId = "Quiz"."QuizId"
         left join (select "QuizId" QuizId,
                           count(1) DislikedCount
                    from "QuizRespect"
                    where "IsDisliked" = true
                    group by "QuizId") as Disliked on Disliked.QuizId = "Quiz"."QuizId"
         join temp_quiz q on "Quiz"."QuizId"= q.QuizId;