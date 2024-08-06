////sayHello();
////sayHelloUser('Bob');
//function sayHello() {
//    console.log('Hello');
//}

//function sayHelloUser(username) {
//    console.log(`Hello ${username}`);
//}

//let data = '321';

//function test() {
//    let data = '123';
//    console.log(data);
//    //console.log(data);
//}

//function custom(p1, p2 = '123', p3) {
//    console.warn('custom function starts');
//    console.log('p1', p1);
//    console.log('p2', p2);
//    console.log('p3', p3);
//    console.warn('custom function ends');
//}
//function custom2(...args) {
//    console.warn('custom2 function starts');
//    for (let p of args) {
//        console.log(p);
//    }
//    console.warn('custom2 function ends');
//}


//custom();
//custom(1);
//custom(1, 2);
//custom(1, 2, 3);
//custom(1, 2, 3, 4);
//custom2(1, 2, 3, 4, 5);

//function sum(a, b) {
//    return a + b;
//}

//console.log(sum(1, '2'));
//let s = sum(1, 2);
//console.log(s);


//function doSmth(p1) {
//    if (p1 == 0) {
//        return null;
//    } else {
//        return p1;
//    }
//}

//function doSmth2(p1) {
//}

//console.log(doSmth(0));
//console.log(doSmth(2));

////test();
////console.log(data);
////console.log(sayHello);

////let f1 = function () {
////    console.log('hello there');
////}

////console.log(f1);
////f1();

function doSmth(p1, p2) {
    console.log(p1, p2);
}

console.log(typeof (doSmth));
//function doSmth() {
//    console.log('Hello there');
//}

//function doSmth(p1) {
//    console.log('Hello there 2');
//}


//doSmth(1, 2);

doSmth = 1;
console.log(typeof (doSmth));

doSmth();

let sum = (a, b) => a + b;
//function(a,b){
//    return a+b;
//}
sum(1, 2);