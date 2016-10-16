

https://fixspec.com/FIX/4.2/Standard-Header#BodyLength
    (Always unencrypted, must be second field in message) 
    Message length, in bytes, forward to the CheckSum field. 
    ALWAYS SECOND FIELD IN MESSAGE. (Always unencrypted) 


http://fixwiki.org/fixwiki/BodyLength
    The message length is verified by counting the number of characters in the message 
    following the BodyLength field up to, and including, the delimiter immediately 
    preceeding the CheckSum tag ("10=")


http://javarevisited.blogspot.co.uk/2011/04/fix-protocol-tutorial-for-beginners.html

http://mechanical-sympathy.blogspot.co.uk/


reading and writing bytes from sockets
            remember it is possible to read a msg length
            i want efficent read until '|' 
                BinaryReader and SXXXReader do not have such a func 
                    although SXXXReader does have ReadUntilNewLine 
                        which shows how to do this
            streams are handy, can test by using a memory stream instead of a network stream
            maybe write my own stream like type, similar to SAEA funcs
                ReadUntilDelim - for reading headers, as header length is unknown
                ReadNBytes - for reading the msg len bytes
                AsyncReadN - for waiting on a new msg, when doing async at the borders
        
                Write
                AsyncFlush
        
            #### remember encoding
            #### would this improve redis performance
            #### would fredisnet.org article
            #### put  this on nuget


consider not publishing the generator
    just publish the results with copyright
        or open source this
    just publish the binaries

    QUICKFIX may have copyright over the xml fix definition file




fsFix article
-------------
    
    advantages
        intellisense, no Set and get functions taking integers
        type safety
            single-case DU
        no separate len fields
		first class components gives correct mapping for optional (or not) components with optional (or not) members
        immutable fields, groups and messages
        consiseness of generated code using ADTs compared to C# classes
        value equality
            if arrays are used instead of lists will there still be value equality?
                could write unit test for this

        fscheck can generate valid fix fields for testing

    using fsFix from C#

    speed? compared to C#, to C++




todo
----

	martin thompsons better fin messaging stuff: http://mechanical-sympathy.blogspot.co.uk/	

	would the 'fixed' help with cache locality

    testing 
		convert fsharp messages back to xml, and diff with original
		CONVERT TYPES BACK TO XML, AND DIFF WITH ORIGINAL

	could fix generation be done with a type provider?

	consider making the type generation a fredis article on its own


	what does it mean for elements to be 'condtionally required' (seen on FIX wiki)?  
		could this be required fields of optional components

	first confirm that the below is required
	have fields and groups appear in the order they do in fixXX.xml

    refactor types, e.g. currently have 
        GroupPC, GroupExp, GroupGen, SubGroup

    finish group factory functions
    
    are any other groups compulsory in the same manner as NoSides
        the NoSides group is compulsory (or else it is either 0, 1 or 2 NoSides groups)

    avoid the need for ClOrdID.ClOrdID etc

    is the length of some fields known? so CrapReadUntilDelim is not needed
        will they always be the same length?
        can this length be known at compile time



    "how to read" msgs scratch
        Manditory field checking
            HashSet of manditory fields
        Optional field checking
            check that no non-thisMsg fields have been received

        read fields in any order
            then check the manditory fields are present
        write fields in the same order

        reading and writing msgs, should I
            use a DU, e.g. FIXMessages and use pattern matching
                runtime, therefore has a cost
            use a static class, and (adhoc) overloading
                compile time - potentially faster than pattern matching
            a map of functions to                 

        how does quickfix read?

    
    how does the quickfix data dictionary relate to my ADT structure

    performance vs C# quickFix
        use Benchmarkdotnet




    probably writing the wrong group definition in msg write functions
        where the group could not be merged, will write to the merged group

    write msg header and tail

    conformant date, datetime and time types


    could the "0" etc below be replaced qwith "0"B? if fldValIn was a byte array and not a string
        let ReadBookingUnit (fldValIn:string) : BookingUnit = 
            match fldValIn with
            |"0" -> BookingUnit.EachPartialExecutionIsABookableUnit
            |"1" -> BookingUnit.AggregatePartialExecutionsOnThisOrderAndBookOneTradePerOrder
            |"2" -> BookingUnit.AggregateExecutionsForThisSymbolSideAndSettlementDate
            | x -> failwith (sprintf "ReadBookingUnit unknown fix tag: %A"  x) 





    change generated write/read file names to fix44.FieldReadWrite etc
        including the fix version means different versions of fix can live side by side


    #NoSides group writing
    #NoSides groups are either "OneSide | BothSides" not 0->many
    #       fix?
    #           special writing for NoSides group
    #           consider non-merged nosides groups
    #           consider a container of 1 or 2 noSides - instead of a list
    #               make invalid states non-representable
    #               this container does not need to be generated
    #           consider one NoSides and another NoSides option         

    is it possible for a group to be required and yet have zero elements
        if not then enforce with typing, i.e. the one var<T> and one list<T>
        

    round-trip fscheck group read-writes
    round-trip fscheck msg read-writes

    consider replacing ReadField impl with one that looks up read functions in a Dictionary, constant time



    consider scott walaschins typesafe DU in debug, raw in release optimisation

    
    support custom fields/msgs
        or could just add them to the xml
    
    add copyright and disclaimer to all files
        DO NOT WANT ANYONE SUING ME BECAUSE THIER FIX APP DID NOT WORK

    put field and msg writing in different functions|source files

    currency code type
        would not use this in the realworld


    

misc thoughts

    do literal tags require allocation each time WriteXXX is called? consider having a tag module


    what form does quickfix take to write and read?
        read:    bytestream -> (bytestream, T)
        write    bytestream -> field -> bytestream


    # let ReadAccount valIn =
    #     let tmp =  valIn
    #     Account.Account tmp

    # let WriteAccount (valIn:Account) : string seq = 
    #     seq{ yield "1"; yield valIn.Value.ToString() }


misc
    http://fixwiki.org/fixwiki/FPL:FIX_Specification#Communicating_using_FIX_over_different_transport_layers





