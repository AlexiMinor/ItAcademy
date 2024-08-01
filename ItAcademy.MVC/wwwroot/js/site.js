////console.log("Hello world again")

//var user = 'User'; //never use
////let message;
////message = 'Hello World';
//const pi = 3.14;

//console.log(user);
////console.log(message);
//console.log(pi);

////pi = 1;
//let a = 10;

//console.log(a);


////types
//let str = 'string';//string
//let x = 10; //number
//let y = 15.5; //number
//let lie = false; // boolean
//let und = undefined; //undefined - value not defined
////let nullable = null; // null - value is null(or we don't know what should it be)
//let obj = { A: 0, B:'a' };

//console.log(str, typeof(str));
//console.log(x, typeof(x));
//console.log(y, typeof (y));
//console.log(lie, typeof (lie));
//console.log(und, typeof (und));
//console.log(null, typeof (null));
//console.log(obj, typeof (obj));


////alert, prompt, confirm
//alert(x);
//let message = prompt("Say smth:", 'hello');
///*let company = 'Company "Hooves And Gloves"'*/

//console.log(message);

//let isAdmin = confirm('Are you admin?');
//console.log(isAdmin);

//type conversion & math operation

//alert, propmt... -> convert value to string
// math operation -> convert values to number (not always)

//let data = true;
//alert(typeof (data));

//data = String(data);
//alert(typeof (data));

//console.log(String(false));
//console.log(String(null));
//console.log(String(undefined));

////convert to Number
//console.log('6' / '2');
//console.log(6 / '2');
//console.log('6' / 2);

//console.log(Number('15'));
//console.log(Number(true));
//console.log(Number('ABC')); //value or NaN
//console.log(Number(null)); //0
//console.log(Number(undefined)); //NaN

//let x = NaN;
//console.log(x, typeof (x));
//let result = 15 / 0;
//console.log(result, typeof (result));

//console.log(Number('    15 \n \t'));
//console.log(Number('1A'));

//console.log(true + 1);
//console.log(1 + true);
//console.log(1 + 'true');
//console.log(1 + '1');
//console.log('2' + 1);
//console.log(Infinity * 2);
//console.log(Infinity + NaN);
//console.log(NaN-NaN);
//console.log(1+NaN);
//console.log(1 + null);
//console.log(1 + undefined);

////boolean
//console.log('BOOLEAN');
//console.log(Boolean(1));
//console.log(Boolean(0));
//console.log(Boolean("hello"));
//console.log(Boolean(""));
//console.log(Boolean("true"));
//console.log(Boolean("false"));
//console.log(Boolean(null));
//console.log(Boolean(undefined));

////+ - * /
//console.log(5 / 2);
////%
//console.log(5 % 2);
//console.log(5 ** 3);//exponentiation
//console.log(5 ** (1/3));//exponentiation


//console.log('Comparisons');

//// > < >= <= == !=
////numbers
//console.log(2 > 1);
//console.log(2 < 1);
//console.log(2 >= 1);
//console.log(2 <= 1);
//console.log(2 == 1);
//console.log(2 != 1);

////strings
//console.log('A' > 'X');
//console.log('Hello' > 'Hi');
//console.log('Bee' > 'Be');
////1. first char. If char bigger - that string is bigger
////2. if char are equal - take 2nd value and repeat until result or string ends
////3. Longer string is bigger

////how to compare dif types
//console.log('different types')
//console.log("'2' > 1",'2' > 1);
//console.log("'01' == 1",'01' == 1);
//console.log("true == 1", true == 1);
//console.log("false == 0", false == 0);
//console.log("'' == 0",'' == 0);
//console.log("'' == false", '' == false);
//console.log(null == undefined);


//let a = 0;
//console.log(Boolean(a));//false

//let b = "0";
//console.log(Boolean(a));//true

//console.log(a == b);//true;
////== convert to same type and compare
//// === compare, but if dif types -> false

//console.log("'01' === 1", '01' === 1);
//console.log("true === 1", true === 1);
//console.log("false === 0", false === 0);
//console.log("'' === 0", '' === 0);
//console.log("'' === false", '' === false);
//console.log("null === undefined", null === undefined);
//console.log("null !== undefined", null !== undefined);

////undefined
//console.log(undefined > 0);
//console.log(undefined < 0);
//console.log(undefined == 0);

////null
//console.log(null > 0);
//console.log(null < 0);
//console.log(null == 0);
//console.log(null >= 0);
//console.log(null <= 0);


let x = true;

if (x)
    console.log('hello there');

if (x) {
    console.log('hello there');
}

if (1) {
    console.log('hello there');
}

if ('') {
    console.log('never will be shown');
} else {
    console.log('hello there');
}


if ('') {
    console.log('never will be shown');
} else if (0) {
    console.log('as well here');
} else if ('yep') {
    console.log('hello there');
} else {
    console.log('no show');
}

let condition = 1 > 2;
let result = condition ? 'ifTrue' : 'ifFalse';

let age = 27;//number

let message = (age < 3) ? 'Hello, baby' : 
    (age < 18) ? 'Hello' : 
        (age < 100) ? 'Greetings' :
            'Wow';


switch (age) {
    case 10:
    case 15: 
        console.log(age);
        break;
    case '20':
        console.log(age);
        break;
    case 20:
        console.log(age);
        break;
    default:
        break;
}