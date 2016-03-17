# TrotTrax Database Organization

## trot_trax

This database serves as the "directory" for TrotTrax. It contains a table for all of the available clubs, as well as a table that lists the last club and year the user was working with. The club ID is an acronym for the club's name, and is generated during new club creation.

All foreign keys are set to cascade on delete, so removing data with a primary key will result in the deletion of all its related data.

Update: Since changing DBMS to SQLite, things like dates and booleans are no longer supported, and the length limitations on INTEGER fields have been removed.

### .club
| Field | Data Type | Key |
| ----- | --------- | --- |
| club\_id | TEXT - not null | primary |
| club\_name | TEXT | |

### .current
| Field  | Data Type | Key |
| ------ | --------- | --- |
| club_id | TEXT - not null | foreign |
| current_year | INTEGER | |

---

## \<club_id\>

The individual club databases, hold data for each club. Each club has one show\_year table which, predictably, holds the list of years entered by the user. The individual year tables are formatted as \<year\>_\<table name\> to eliminate the need for a million multi-column keys.

### .show_year
| Field | Data Type | Key |
| ----- | --------- | --- |
| year  | INTEGER - not null | unique |

### .\<year\>_rider
| Field | Data Type | Key |
| ----- | --------- | --- |
| rider_no | INTEGER - not null, auto-increment | primary |
| rider_first | TEXT - not null | |
| rider_last | TEXT - not null | |
| rider_dob | INTEGER(date) | |
| phone | TEXT | |
| email | TEXT | |
| member | INTEGER(boolean) - default 0 | |
| rider_comment | TEXT | |

### .\<year\>_horse
| Field | Data Type | Key |
| ----- | --------- | --- |
| horse_no | INTEGER - not null, auto-increment | primary |
| horse_name | TEXT - not null | |
| horse_alt | TEXT | |
| height | TEXT | |
| owner_name | TEXT | |
| horse_comment | TEXT | |

### .\<year\>_backNo
| Field | Data Type | Key |
| ----- | --------- | --- |
| back_no | INTEGER - not null | primary |
| rider_no | INTEGER - not null | foreign |
| back_no | INTEGER - not null | foreign |

### .\<year\>_show
| Field | Data Type | Key |
| ----- | --------- | --- |
| show_no | INTEGER - not null - auto-increment | primary |
| date | INTEGER(date) - not null | unique |
| show_name | TEXT | |
| show_comment | TEXT | |

### .\<year\>_category
| Field | Data Type | Key |
| ----- | --------- | --- |
| cat_no | INTEGER - not null, auto-increment | primary |
| cat_desc | TEXT | |
| timed | INTEGER(boolean) - not null | |

### .\<year\>_class
| Field | Data Type | Key |
| ----- | --------- | --- |
| class_no | INTEGER - not null | primary |
| cat_no | INTEGER - not null| foreign |
| class_name | TEXT - not null | |
| timed | INTEGER | |
| fee | REAL | |

### .\<year\>_result
| Field | Data Type | Key |
| ----- | --------- | --- |
| show_no | INTEGER - not null | foreign |
| class_no | INTEGER - not null | foreign |
| back_no | INTEGER - not null | foreign |
| place | INTEGER | |
| time | REAL | |
| points | INTEGER - default 0 | |
| paid_in | REAL - default 0 | |
| paid_out | REAL | |
