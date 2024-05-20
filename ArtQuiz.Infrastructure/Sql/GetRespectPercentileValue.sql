select percentile_cont(@percentile) within group ( order by Respect ) as percentile
from (select q."QuizId",
             (LikedCount - DislikedCount) Respect
      from (select QuizId,
                   CASE
                       WHEN LikedCount is null THEN 0
                       WHEN LikedCount is not null THEN LikedCount
                       END AS LikedCount,
                   CASE
                       WHEN DislikedCount is null THEN 0
                       WHEN DislikedCount is not null THEN DislikedCount
                       END AS DislikedCount
            from (select Liked.QuizId           QuizId,
                         Liked.LikedCount       LikedCount,
                         Disliked.DislikedCount DislikedCount
                  from (select "QuizId" QuizId,
                               count(1) LikedCount
                        from "QuizRespect"
                        where "IsLiked" = true
                        group by "QuizId") as Liked
                           left join (select "QuizId" QuizId,
                                             count(1) DislikedCount
                                      from "QuizRespect"
                                      where "IsDisliked" = true
                                      group by "QuizId") as Disliked
                                     on Liked.QuizId = Disliked.QuizId) as respects) as respect2
               join "Quiz" q on q."QuizId" = respect2.QuizId
      where (@isUseDate = false or q."CreatedOn" > @date)
        and q."Application" = @applicationType
        and q."Language" = @languageType
        and (q."Type" & @type) = q."Type"
        and (q."Theme" & @theme) = q."Theme") as respect3