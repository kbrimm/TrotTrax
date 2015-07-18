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
+ [Copyright Notice](#copyright)

<a id="functional"></a>
Functional Requirements 
-----------------------

<a id="store"></a>
### Data Storage 

The primary function of TrotTrax is to store data. Because the information stored interacts in some fairly complicated ways, I've broken it down in to the following data storage hierarchy:
+ Club data - Name, ID
    + Show Years
        + Back Numbers
            + Rider information - first & last names, age, contact information, membership status
            + Horse information - full name, nickname, height
        + Class List - class name, class number, class category, entry fee
            + Class Category - points type, timed status, jackpot status 
        + Shows - date, description, comments
            + Points - class number, back number, place, time (if timed), fee paid, payout received

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

<a id="manipulate"></a>
### Data Manipulation 

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
    
<a id="report"></a>
### Report Generation 
    
An important secondary function of TrotTrax is to generate reports. These reports must be available in a standard, print-sized .pdf format for printing on location, emailing, or availability on the internet. 
The following reports can be generated on a per show or yearly basis:
+ Back Number
    + Placing data: Classes entered, place taken, time (for timed events), overall points, points by class category
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

<a id="nice"></a>
### Nice To Have 

Nice-to-haves:
+ Family grouping for riders/back numbers
+ Detailed financial tracking involving fees for horses, trailer parking, membership fees and record of payments made
+ Owner grouping for horses
+ HTML generation for reports to post on club website

<a id="nonfunctional"></a>
Non-Functional Requirements 
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

<a id="copyright"></a>
Copyright Notice
----------------

TrotTrax is copyright (c) 2015 Katy Brimm

This source file is licensed under the GNU General Public License. Please see the file LICENSE in this distribution for license terms.

Contact: kbrimm@pdx.edu
