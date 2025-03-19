USE FamousPeopleDB

UPDATE FamousHuman
SET Image = REPLACE(Image, 'C:\Users\Olya\Desktop\', '')
WHERE Image LIKE 'C:\Users\Olya\Desktop\%';

UPDATE FamousHuman
SET Image = CONCAT('C:\Users\Olya\Desktop\', Image);
