
var isgregorian = 1;


//english or hijri
function loadCalender(type)
{
	$("#result").html("");
	if(type == 1)
	{
		loadEnglishCalender(5);
	}
	else
	{
		loadHijriCalender(5);
	}
}

function loadEnglishCalender(moreyear)
{
	var options = "";
	var date = new Date();
	var currentYear = date.getFullYear();

	var currentMonth = date.getMonth();

	var currentDate = date.getDate();

	var limit = currentYear + moreyear;
	var startDate = currentYear - 100;

	var selected = " selected=\"selected\" ";
	for(var i = startDate; i <= limit; i++)
	{
		if(currentYear == i)
		{
			options = options + "<option "+selected+" value=\""+i+"\">"+i+"</option>";
		}
		else
		{
			options = options + "<option value=\""+i+"\">"+i+"</option>";
		}
	}

	$("#cayear").val(currentYear);

	options = "";

	for(var i = 1; i <= 31; i++)
	{
		if(currentDate == i)
		{
			options = options + "<option "+selected+"  value=\""+i+"\">"+i+"</option>";
		}
		else
		{
			options = options + "<option  value=\""+i+"\">"+i+"</option>";
		}
	}

	$("#caday").html(options);


	options = "";

	for(var i = 0; i < 12; i++)
	{
		if(currentMonth == i)
		{
			options = options + "<option  "+selected+" value=\""+i+"\">"+(i+1) + ' - ' + getEnglishMonthFullName(i)+"</option>";
		}
		else
		{
			options = options + "<option value=\""+i+"\">"+(i+1) + ' - ' + getEnglishMonthFullName(i)+"</option>";
		}
	}

	$("#camonth").html(options);

}

function loadHijriCalender(moreyear)
{
	var options = "";
	var date = new Date();

	var hijriDate = GregToHijri(date);

	var currentYear = hijriDate[0];

	var currentMonth = hijriDate[1];

	var currentDate = hijriDate[2];

	var limit = currentYear + moreyear;
	var startDate = currentYear - 100;

	var selected = " selected=\"selected\" ";

	for(var i = startDate; i <= limit; i++)
	{
		if(currentYear == i)
		{
			options = options + "<option "+selected+" value=\""+i+"\">"+i+"</option>";
		}
		else
		{
			options = options + "<option value=\""+i+"\">"+i+"</option>";
		}
	}

	$("#cayear").val(currentYear);

	options = "";

	for(var i = 1; i <= 31; i++)
	{
		if(currentDate == i)
		{
			options = options + "<option "+selected+"  value=\""+i+"\">"+i+"</option>";
		}
		else
		{
			options = options + "<option  value=\""+i+"\">"+i+"</option>";
		}
	}

	$("#caday").html(options);


	options = "";

	for(var i = 0; i < 12; i++)
	{
		if((currentMonth-1) == i)
		{
			options = options + "<option  "+selected+" value=\""+i+"\">"+(i+1) + ' - ' + getHijriMonthName(i)+"</option>";
		}
		else
		{
			options = options + "<option value=\""+i+"\">"+(i+1) + ' - ' + getHijriMonthName(i)+"</option>";
		}
	}

	$("#camonth").html(options);
}
function selectCalenderType(type)
{
	if(type ==1)
	{
		isgregorian = 1;
		loadCalender(1);
		$("#englishCal").addClass("selected-btn");
		$("#hijriCal").removeClass("selected-btn");
	}
	else
	{
		isgregorian = 0;
		loadCalender(0);
		$("#englishCal").removeClass("selected-btn");
		$("#hijriCal").addClass("selected-btn");
	}
	$("btnConverter").focus();
}

function weekDay(wdn,plusWhat){

	if ( plusWhat == '+arabic' ){
		if(wdn==0){
			return "Sunday (Al-Ahad)"
			}
		if(wdn==1){
			return "Monday (Al-Ithnayn)"
			}
		if(wdn==2){
			return "Tuesday (Ath-Thalatha)"
			}
		if(wdn==3){
			return "Wednesday (Al-Arba'a)"
			}
		if(wdn==4){
			return "Thursday (Al-Khamees)"
			}
		if(wdn==5){
			return "Friday (Al-Jum'ah)"
			}
		if(wdn==6){
			return "Saturday (As-Sabt)"
			}
	} else {
		if(wdn==0){
			return "Al-Ahad (Sunday)"
			}
		if(wdn==1){
			return "Al-Ithnayn (Monday)"
			}
		if(wdn==2){
			return "Ath-Thalatha (Tuesday)"
			}
		if(wdn==3){
			return "Al-Arba'a (Wednesday)"
			}
		if(wdn==4){
			return "Al-Khamees (Thursday)"
			}
		if(wdn==5){
			return "Al-Jum'ah (Friday)"
			}
		if(wdn==6){
			return "As-Sabt (Saturday)"
			}
	}

}


function convert()
{
	$("#result").html("");
	if(!isValidYear($("#cayear").val()))
	{
		return false;
	}
	$("#result").html("");
	var day = parseInt($("#caday").val());
	var month = parseInt($("#camonth").val()) + 1;
	var year = parseInt($("#cayear").val());

	if(isgregorian == 1)
	{
		//var output = "<hr/><p><strong>Convert Gregorian to Hijri</strong><br/>";
		var output = "<hr/><strong>CONVERTED DATE</strong><br/><strong>";
		var date =  new Date(""+year+"/"+month+"/"+day);
		var hijriDate = GregToHijri(date);

		output = output + getHijriMonthName(hijriDate[1]-1)+" "+hijriDate[2]+", "+hijriDate[0];

		//---------------------------------------------------------------
		var current_date_as_string = getEnglishMonthFullName(month-1) +  " " + day + ", " + year;
		var current_date_as_date = new Date(current_date_as_string);
 		var current_day = weekDay(date.getDay(),'+english');


		output = output + "<br>" + current_day + "</strong></p><p>&nbsp</p>";
		//---------------------------------------------------------------

		$("#result").html(output);
		$('#result').addClass('animated bounceIn');
	}
	else
	{
		var output = "<hr/><p><strong>CONVERTED DATE</strong><br/><strong>";
		//var output = "<hr/><p><strong>Convert Hijri to Gregorian</strong><br/><strong>CONVERTED DATE - ";

		var date =  new Array(year,month,day);
		var englishDate = HijriToGreg(date);

		output = output + getEnglishMonthFullName(englishDate[1]-1)+" "+englishDate[2]+", "+englishDate[0];

		//---------------------------------------------------------------
		var current_date_as_string = getEnglishMonthFullName(englishDate[1]-1)+" "+englishDate[2]+", "+englishDate[0];
		var current_date_as_date = new Date(current_date_as_string);
 		var current_day = weekDay(current_date_as_date.getDay(),'+arabic');
		output = output + "<br>" + current_day + "</strong></p><p>&nbsp</p>";
		//---------------------------------------------------------------

		$("#result").html(output);
		$('#result').addClass('animated bounceIn');
	}

	setTimeout("removeAnimation()",3000);
}
function isValidYear(year)
{
	year = parseInt(year);
	// check valid integer
	if(Number.isInteger(year) === false)
	{
		alert("Invalid year!");
		return false;
	}

	$("#cayear").val(year);

	//check valid range
	if(isgregorian == 1)
	{
		if(year >= 622 && year <= 2076)
		{
			return true;
		}
		else
		{
			alert("Invalid Year: "+year+"\nValid Range: 622 to 2076");
			return false;
		}
	}
	else
	{
		if(year >= 1 && year <= 1500)
		{
			return true;
		}
		else
		{
			alert("Invalid Year: "+year+"\nValid Range: 1 to 1500");
			return false;
		}

	}
}
function removeAnimation()
{
	$('#result').removeClass('animated bounceIn');
}
$(document).ready(function(){

	loadCalender(1);
	setsharedlinkhijri();
});
         