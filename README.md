# GeoInfo [![Build status](https://ci.appveyor.com/api/projects/status/hk5720wxk67jay55?svg=true)](https://ci.appveyor.com/project/carlosjdelgado/geoinfo)

A powerful geo political library data based on GeoNames database dump (http://download.geonames.org/export/dump/)

You can get information of all countries and for cities with a population greather than 1000 people.

This is the info you can get with this library wich is totally offline:

#### Cities:
* Name (with translations)
* Latitude and longitude
* Time zone (Iana and windows)
* Local time
* Population
* PostalCode and it regex
* Phone prefix
* Iata code if have
* Country
* Altitude in meters


#### Countries:
* Name (with translations)
* Currency
* Population
* Area
* Internet domain
* Languages
* Continent Code

Package is current in alpha state, data layer is based on SqlServerCE, and you can get it by nuget (https://www.nuget.org/packages/GeoInfo/)

I need too much help for improve performance and resolve some bugs, and also detect others, so... if you like you can contribute with the project.
