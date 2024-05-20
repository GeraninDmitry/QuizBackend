select u."Id"                  as Id,
       u."UserName"            as Name,
       ui."Image"              as Image,
       fui.SubscriptionsAmount as SubscriptionsAmount
from "AspNetUsers" u
         left join "UserImage" ui on ui."UserId" = u."Id"
         left join (select "FollowedUserId",
                           count(1) SubscriptionsAmount
                    from "UserFollower"
                    where "FollowedUserId" = @userId
                    and "IsFollowing" = true
                    group by "FollowedUserId") as fui on fui."FollowedUserId" = u."Id"
where u."Id" = @userId;