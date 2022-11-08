﻿module Lesson4

module Map =

    // map : ('a -> 'b) -> 'a list -> 'b list
    let rec map f l =
        match l with
        | [] -> []
        | x :: xs -> f x :: map f xs

    let bool_list = map (fun x -> x >= 10) [3; 88; 4; 10]

    let strings_to_ints = map (fun s -> String.length s) ["ciao"; "sono"; "alvise"]

    // add1 : int * int -> int
    let add_uncurried = fun (x, y) -> x + y

    // add2 : int -> int -> int
    let add_curried = fun x -> (fun y -> x + y)

    let call_uncurried = add_uncurried (3, 4)     // uncurried form, i.e. with tuples

    let call_curried = add_curried 3 4        // CURRIED form

    let f = add_curried 8

    let ten = f 2

    let map_length = map String.length

    let map_id x = map id x

    (*
    public static <A, B> List<B> map(Function<A, B> f, List<A> l) {
        List<B> r = new ArrayList<B>();
        for (A x : l) {
            B b = f.apply(x);
            r.add(b);
        }
        return r;
    }
    *)

module Filter =

    // filter : ('a -> bool) -> 'a list -> 'a list
    let rec filter f l =
        match l with
        | [] -> []
        | x :: xs -> if f x then x :: filter f xs else filter f xs

    let ex1 = filter (fun x -> x > 5) [1 .. 30]

    let ex2 = filter id (Map.map (fun x -> x < 10) [1 .. 20])


module Sum =
    
    let rec sum_ints l =
        match l with 
        | [] -> 0
        | x :: xs -> x + sum_ints xs

    let rec sum plus zero l =
        match l with 
        | [] -> zero
        | x :: xs -> plus x (sum plus zero xs)

    let ex1 = sum (+) 0. [1.0; 2.22; 67.34]

    let ex2 = sum (+) 0 [1 .. 20]

    let ex3 = sum (+) "" ["ciao"; "pippo"; "baudo"]

    let ex4 = sum (fun a b -> a || b) false [true; false; true; false]


