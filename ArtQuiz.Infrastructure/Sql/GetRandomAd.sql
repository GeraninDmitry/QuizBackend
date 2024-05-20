select "AdId"  as AdId,
       "Title" as Title,
       "Image" as Image,
       "Text"  as Text
from "Ad"
where "Application" = @applicationType
  and "Language" = @languageType
  and "IsActive" = true
  and ("IsForAuthorizedUser" is null or "IsForAuthorizedUser" = @isAuth)
  and ("IsRepeating" = true or @isAuth = false or
       "AdId" not in (select "AdLog"."AdId"
                      from "AdLog"
                      where "UserId" = @userId))
  and ("StartDate" is null or @date > "StartDate")
  and ("EndDate" is null or @date < "EndDate")