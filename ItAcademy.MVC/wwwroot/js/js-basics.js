{ 
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


//let x = true;

//if (x)
//    console.log('hello there');

//if (x) {
//    console.log('hello there');
//}

//if (1) {
//    console.log('hello there');
//}

//if ('') {
//    console.log('never will be shown');
//} else {
//    console.log('hello there');
//}


//if ('') {
//    console.log('never will be shown');
//} else if (0) {
//    console.log('as well here');
//} else if ('yep') {
//    console.log('hello there');
//} else {
//    console.log('no show');
//}

//let condition = 1 > 2;
//let result = condition ? 'ifTrue' : 'ifFalse';

//let age = 27;//number

//let message = (age < 3) ? 'Hello, baby' :
//    (age < 18) ? 'Hello' :
//        (age < 100) ? 'Greetings' :
//            'Wow';


//switch (age) {
//    case 10:
//    case 15:
//        console.log(age);
//        break;
//    case '20':
//        console.log(age);
//        break;
//    case 20:
//        console.log(age);
//        break;
//    default:
//        break;


    //let array = new Array(); 
    //let array2 = [];

    //let cities = ['New York', 'Minsk', "Berlin"];

    //console.log(cities[0]);
    //console.log(cities[1]);
    //console.log(cities[2]);

    //cities[2] = 'Paris';
    //console.log(cities[2]);

    //console.log(cities);
    //console.log(cities.length);

    //array = ['Hello', 123, true, { name: 'Bob' }, function () { console.log('Hello world') }];
    //console.log('array[0]', array[0]);
    //console.log('array[1]', array[1]);
    //console.log('array[2]', array[2]);
    //console.log('array[3]', array[3]);
    //console.log('array[4]', array[4]);
    //console.log('array[5]', array[5]);

    //console.log(array.length);
    //array[4]();

    //console.log(cities.at());
    //console.log(cities.at(-1));
    ////if param >= 0 -> same as arr[i]
    ////if param < 0 -> steps back from last (-1 is last one)

    //cities[10] = 'Madrid';
    //console.log(cities);
    //console.log(cities.length);


    //array2 = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
    //console.log(array2);

    ////push - add element to end
    ////pop - take element from the end
    ////shift - get element from the begfinning
    ////unshift - add element to the begfinning
    //array2.push(10);
    //console.log(array2);
    //console.log(array2.length);


    //console.log('pop', array2.pop());
    //console.log('length after pop', array2.length);

    //console.log('shift', array2.shift());
    //console.log('length after shift', array2.length);

    //array2.unshift(0);
    //console.log(array2);
    //console.log(array2.length);

    //console.log(typeof (array2));
    //array2.X = 15;
    //console.log(array2);
    //console.log(array2.X);
    //console.log(array2['X']);

    //array = [1, 2, 3];
    //console.log(String(array));


    //console.log([] == []);
    //console.log(0 == []);
    //console.log('0' == []);
    //console.log([1,2,3] == [1,2,3]);

    //console.log([] === []);
    //console.log([1,2,3] === [1,2,3]);


    //loops
    let i = 0;
    while (i < 3) {
        console.log(i);
        i++;
    }

    i = 0;
    do {
        console.log(i);
        i++;
    } while (i < 3);

    //do {
    //    console.log(i);
    //    i++;
    //} while (i < 3)

    for (let x = 0; x <= 3; x++) {
        console.log(x);
    }

    //continue;
    //break;
    //return;
    let array = ['a', 'b', 'c'];
    for (let item of array) {
        console.log(item);
    }

    let o = { A: 1, b: '2', C: 1235 }
    for (let item in o) {
        console.log(item);
    }
    for (let item of o) {
        console.log(item);
    }
}