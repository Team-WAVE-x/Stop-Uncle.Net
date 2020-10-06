# Stop-Uncle.Net
## 소개
Stop-Uncle의 닷넷 버전입니다.

## 해야할 일
 - 아재개그 DB 제작
 -  MySQL 연동

## DB 구조
```sql
CREATE TABLE aje_db
( 
  _id INT PRIMARY KEY AUTO_INCREMENT,
  que TEXT NOT NULL,
  answer TEXT NOT NULL
) ENGINE=INNODB;
DESCRIBE aje_db;
```
