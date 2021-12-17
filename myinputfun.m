function ctemp = myinputfun(ftemp)
    %FAHR_TO_CELSIUS   Convert Fahrenheit to Celcius
   ktemp = ((ftemp-32)*(5.0/9.0)) + 273.15;
   ctemp = ktemp - 273.15;
end

