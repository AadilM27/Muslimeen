
var adjustDate = document.getElementById('hfAdjustDate').value;

document.getElementById("lstIslamicDate").innerHTML = displayGregDate() + ' | ' + displayHijriDate(adjustDate);


function displayGregDate() {
var d = new Date(),
	minutes = d.getMinutes().toString().length == 1 ? '0'+d.getMinutes() : d.getMinutes(),
	hours = d.getHours().toString().length == 1 ? '0'+d.getHours() : d.getHours(),
	ampm = d.getHours() >= 12 ? 'pm' : 'am',
	months = ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'],
	days = ['Sun','Mon','Tue','Wed','Thu','Fri','Sat'];
//return days[d.getDay()]+' '+months[d.getMonth()]+' '+d.getDate()+' '+d.getFullYear()+' '+hours+':'+minutes+ampm;
    return d.getFullYear() + ' - ' + months[d.getMonth()] + ' - ' + d.getDate();
}

/*this will evetually go into *.js file */
/*code credit goes to http://www.al-habib.info/islamic-calendar/hijricalendartext.htm */
function gmod(n,m){
	return ((n%m)+m)%m;
}

function kuwaiticalendar(adjust){
	var today = new Date();
	if(adjust) {
		adjustmili = 1000*60*60*24*adjust;
		todaymili = today.getTime()+adjustmili;
		today = new Date(todaymili);
	}
	day = today.getDate();
	month = today.getMonth();
	year = today.getFullYear();
	m = month+1;
	y = year;
	if(m<3) {
		y -= 1;
		m += 12;
	}

	a = Math.floor(y/100.);
	b = 2-a+Math.floor(a/4.);
	if(y<1583) b = 0;
	if(y==1582) {
		if(m>10)  b = -10;
		if(m==10) {
			b = 0;
			if(day>4) b = -10;
		}
	}

	jd = Math.floor(365.25*(y+4716))+Math.floor(30.6001*(m+1))+day+b-1524;

	b = 0;
	if(jd>2299160){
		a = Math.floor((jd-1867216.25)/36524.25);
		b = 1+a-Math.floor(a/4.);
	}
	bb = jd+b+1524;
	cc = Math.floor((bb-122.1)/365.25);
	dd = Math.floor(365.25*cc);
	ee = Math.floor((bb-dd)/30.6001);
	day =(bb-dd)-Math.floor(30.6001*ee);
	month = ee-1;
	if(ee>13) {
		cc += 1;
		month = ee-13;
	}
	year = cc-4716;

	if(adjust) {
		wd = gmod(jd+1-adjust,7)+1;
	} else {
		wd = gmod(jd+1,7)+1;
	}

	iyear = 10631./30.;
	epochastro = 1948084;
	epochcivil = 1948085;

	shift1 = 8.01/60.;

	z = jd-epochastro;
	cyc = Math.floor(z/10631.);
	z = z-10631*cyc;
	j = Math.floor((z-shift1)/iyear);
	iy = 30*cyc+j;
	z = z-Math.floor(j*iyear+shift1);
	im = Math.floor((z+28.5001)/29.5);
	if(im==13) im = 12;
	id = z-Math.floor(29.5001*im-29);

	var myRes = new Array(8);

	myRes[0] = day; //calculated day (CE)
	myRes[1] = month-1; //calculated month (CE)
	myRes[2] = year; //calculated year (CE)
	myRes[3] = jd-1; //julian day number
	myRes[4] = wd-1; //weekday number
	myRes[5] = id; //islamic date
	myRes[6] = im-1; //islamic month
	myRes[7] = iy; //islamic year

	return myRes;
}
function displayHijriDate(adjustment) {
	var wdNames = new Array("Ahad","Ithnin","Thulatha","Arbaa","Khams","Jumuah","Sabt");
	//var iMonthNames = new Array("Muharram","Safar","Rabi'ul Awwal","Rabi'ul Akhir","Jumadal Ula","Jumadal Akhira","Rajab","Sha'ban","Ramadan","Shawwal","Dhul Qa'ada","Dhul Hijja");
	
	var iMonthNames = new Array("Muharram","Safar","Rabi Al-Awwal","Rabi Al-Thani","Jumada Al-Awwal","Jumada Al-Thani","Rajab","Sha'ban","Ramadaan","Shawwal","Dhul-Qa'dah","Dhul-Hijjah");
	
	
	var iDate = kuwaiticalendar(adjustment);
	/*
	var outputIslamicDate = wdNames[iDate[4]] + ", "
	+ iDate[5] + " " + iMonthNames[iDate[6]] + " " + iDate[7] + " AH";
	*/
    var outputIslamicDate = iDate[7] + " - " + iMonthNames[iDate[6]] + " - " + iDate[5];

	return outputIslamicDate;
}
//document.write (displayGregDate());
//document.write (' | ' + displayHijriDate()); //fix for june 6,2016 being shaban 29
//document.write (' | ' + displayHijriDate(-1)); //fix for bad ramadan 3 to be good ramadan 2 - change made on may 28 bu mustafa
//document.write (' | ' + displayHijriDate()); //fix for bad ramadan 3 to be good ramadan 2 - change made on aug 24, 2017 by mustafa
//document.write (' | ' + displayHijriDate(-1));