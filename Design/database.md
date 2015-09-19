# TrotTrax Database Organization

## trot_trax

This database serves as the "directory" for TrotTrax. It contains a table for all of the available clubs, as well as a table that lists the last club and year the user was working with. The club ID is an acronym for the club's name, and is generated during new club creation.

It is worth noting that all foreign keys are set to cascade on delete, so removing data with a primary key will result in the deletion of all its related data.

### .club
| Field | Data Type | Key |
| ----- | --------- | --- |
| club\_id | varchar(10) - not null | primary |
| club\_name | varchar(255) | |

### .current
| Field  | Data Type | Key |
| ------ | --------- | --- |
| club_id | varchar(10) - not null | foreign |
| current_year | int | |

---

## \<club_id\>

The individual club databases, hold data for each club. Each club has one show\_year table which, predictably, holds the list of years entered by the user. The individual year tables are formatted as \<year\>_\<table name\> to eliminate the need for a million multi-column keys.

### .show_year
| Field | Data Type | Key |
| ----- | --------- | --- |
| year  | int - not null | unique |

### .\<year\>_rider
| Field | Data Type | Key |
| ----- | --------- | --- |
| rider_no | int - not null, auto-increment | primary |
| rider_first | varchar(255) - not null | |
| rider_last | varchar(255) - not null | |
| rider_age | int | |
| phone | varchar(255) | |
| email | varchar(255) | |
| member | boolean - default false | |

### .\<year\>_horse
| Field | Data Type | Key |
| ----- | --------- | --- |
| horse_no | int - not null, auto-increment | primary |
| horse_name | varchar(255) - not null | |
| horse_call | varchar(255) | |
| height | decimal(5,2) | |
| owner_name | varchar(255) | |

### .\<year\>_backNo
| Field | Data Type | Key |
| ----- | --------- | --- |
| back_no | int - not null | primary |
| rider_no | int - not null | foreign |
| back_no | int - not null | foreign |

### .\<year\>_show
| Field | Data Type | Key |
| ----- | --------- | --- |
| show_no | int - not null - auto-increment | primary |
| date | date - not null | unique |
| show_name | varchar(255) | |
| show_comment | varchar(500) | |

### .\<year\>_category
| Field | Data Type | Key |
| ----- | --------- | --- |
| cat_no | int - not null, auto-increment | primary |
| cat_desc | varchar(255) | |
| fee | decimal(5,2) - not null | |
| timed | boolean - not null | |
| payout | boolean - not null | |
| jackpot | boolean - not null | |

### .\<year\>_class
| Field | Data Type | Key |
| ----- | --------- | --- |
| class_no | int - not null | primary |
| cat_no | int - not null| foreign |
| class_name | varchar(255) - not null | |

### .\<year\>_result
| Field | Data Type | Key |
| ----- | --------- | --- |
| show_no | int - not null | foreign |
| class_no | int - not null | foreign |
| back_no | int - not null | foreign |
| place | int | |
| time | decimal(6,3) | |
| points | int - default 0 | |
| paid_in | decimal(5,3) - default 0 | |
| paid_out | decimal(5,3) | |
