Requirements
============

This document describes the requirements for Trot Trax. Essentially, this outlines the things the system needs to do and how it needs to do them.

### Contents
+ [Functional Requirements](#functional)
    + [Data Storage](#store)
    + [Data Manipulation](#manipulate)
    + [Report Generation](#report)
    + [Nice-To-Have](#nice)
+ [Nonfunctional Requirements](#nonfunctional)

Functional Requirements <a id="functional"></a>
-----------------------

### Data Storage <a id="store"></a>

The primary function of TrotTrax is to store data. Because the information stored interacts in some fairly complicated ways, I've broken it down in to the following data storage hierarchy:
+ Club data - Name, ID
    + Show Years
        + Back Numbers - points totals
            + Rider information - first & last names, contact information, membership status, finance totals (payments, awards, payouts)
            + Horse information - full name, nickname
        + Class List - class name, class number, type (timed, judged, age group, etc), points designation, entry fee
        + Shows - date, description
            + Points - show date, class number, back number, placing, total entries

A few notes on data relationships and aggregation:
+ Each back number is a unique combination of rider and horse
+ Points are accumulated per back number
+ The points received from each class is determined by a formula that looks at the place achieved and the number of entries in the class
+ As of 07/18/15, the points scale for the Black Hawk Creek Saddle Club was:
```
    |Place\# In class| 1 | 2 | 3 | 4 | 5 | 6 + |
    |              1 | 5 | 6 | 7 | 8 | 9 | 10  |
    |              2 |   | 5 | 6 | 7 | 8 | 9   |
    |              3 |   |   | 5 | 6 | 7 | 8   |
    |              4 |   |   |   | 5 | 6 | 7   |
    |              5 |   |   |   |   | 5 | 6   |
    |              6 |   |   |   |   |   | 5   |
```
+ Each class has an entry fee; non-members pay extra.
+ Payouts are weighted according to the formula: 2x no. of entries x a percentage based on placing:
    + 40% for 1st, 30% for 2nd, 20% for 3rd, 10% for 4th
    + Jackpot classes yield double the reward

### Data Manipulation <a id="manipulate"></a>

The user must be able to interact with the data in the following ways:
+ Clubs
    + Add/remove clubs
    + Modify club name
+ Show Years
    + Add/remove years (Note: removing a year or club will result in destroying a significant amount of data)
+ Back Numbers
    + Add new numbers
    + Remove empty number
+ Riders & Horses
    + Add/modify
+ Class List
    + Add new classes
    + Modify existing classes (Note: this will not retroactively change point or financial assignments)
+ Shows
    + Add new show
    + Remove empty show
    
### Report Generation <a id="report"></a>
    
An important secondary function of TrotTrax is to generate reports. These reports must be available in a standard, print-sized .pdf format for printing on location, emailing, or availability on the internet. 
The following reports can be generated on a per show or yearly basis:
+ Back Number
    + Placing data: Classes entered, place taken, time (for timed events), points won.
+ Rider
    + Aggregated back number data with point and financial totals
    + Classes entered (For use on the day of the show, indicates which classes have been paid for)
+ Classes
    + List of entries
    + Entries ranked by place taken, including time for timed events
+ Show
    + List of classes
    + List of entrants with back nos broken down by rider->horses
    + Financial data broken down by classes
+ Year-End
    + Total financial report
    + Total points for each back no

### Nice To Have <a id="nice"></a>

Nice-to-haves:
+ Family grouping for riders/back numbers
+ Owner grouping for horses
+ HTML generation for reports to post on club website

Non-Functional Requirements <a id="nonfunctional"></a>
---------------------------

These are set in stone, and required for the initial build:
+ Microsoft Windows 7/8 compatible
+ Local database
+ Easy-to-navigate GUI
+ Language: C#
+ Database: MySQL

Some nice-to-haves:
+ Local network connectivity
+ Tablet-friendly interface
+ Email integration to send points and financial reports to members
