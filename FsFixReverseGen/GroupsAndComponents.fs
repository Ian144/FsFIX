(*
 * Copyright (C) 2016-2017 Ian Spratt <ian144@hotmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301, USA.
 *
 *)
 
module GroupsAndComponents

open ParseData

let componentOrderMap = 
    [   
        ("Instrument", 1)
        ("InstrumentFG", 2)
        ("UnderlyingInstrument", 3)
        ("UnderlyingInstrumentFG", 4)
        ("InstrumentLeg", 5)
        ("InstrumentLegFG", 6)
        ("InstrumentExtension", 7)
        ("InstrumentExtensionFG", 8)
        ("OrderQtyData", 9)
        ("OrderQtyDataFG", 9)
        ("CommissionData", 10)
        ("CommissionDataFG", 11)
        ("Parties", 12)
        ("PartiesFG", 13)
        ("NestedParties", 14)
        ("NestedPartiesFG", 15)
        ("NestedParties2", 16)
        ("NestedParties2FG", 17)
        ("NestedParties3", 18)
        ("NestedParties3FG", 19)
        ("SettlParties", 20)
        ("SettlPartiesFG", 21)
        ("SpreadOrBenchmarkCurveData", 22)
        ("SpreadOrBenchmarkCurveDataFG", 23)
        ("LegBenchmarkCurveData", 24)
        ("LegBenchmarkCurveDataFG", 25)
        ("Stipulations", 26)
        ("StipulationsFG", 27)
        ("UnderlyingStipulations", 28)
        ("UnderlyingStipulationsFG", 29)
        ("LegStipulations", 30)
        ("LegStipulationsFG", 31)
        ("YieldData", 32)
        ("YieldDataFG", 33)
        ("PositionQty", 34)
        ("PositionQtyFG", 35)
        ("PositionAmountData", 36)
        ("PositionAmountDataFG", 37)
        ("TrdRegTimestamps", 38)
        ("TrdRegTimestampsFG", 39)
        ("SettlInstructionsData", 40)
        ("SettlInstructionsDataFG", 41)
        ("PegInstructions", 42)
        ("PegInstructionsFG", 43)
        ("DiscretionInstructions", 44)
        ("DiscretionInstructionsFG", 45)
        ("FinancingDetails", 46)
        ("FinancingDetailsFG", 47)        ]
    |> Map.ofList    




let convCmpGrpChunk (pds:ParseData list) =
    match pds with
    |   namePd::memberPds   -> 
        let msgName = getTypeName namePd
        let members = memberPds |> List.map (fun msgPd ->
            let _, xx = getMember msgPd
            let isRequired = xx.Contains("option") |> not
            let subStrs = (xx.Split ' ')
            let typeName = subStrs.[0].Trim()
            if xx.Contains("// group") then
                Member.Group (typeName, isRequired)
            else if xx.Contains "// component" then
                Member.Component (typeName, isRequired)
            else
                Member.Field (typeName, isRequired)
        )
        { CGName=msgName; Members=members }
    |   _   -> failwith "failed to parse msg"


let componentGroupPartitionPred (pds:ParseData list) =
    let typeName = pds.Head |> getTypeName
    typeName.EndsWith "Grp"


let printComponent (grpMap:Map<string,Member list>) (cmp:CmpGrp) : unit = 
    printfn "        <component name=\"%s\">" cmp.CGName
    cmp.Members |> List.iter (printMember "" grpMap)
    printfn "        </component>"


// tests if this component or group parse data instance a member of the same component or group as the previous
// 
let isSameGrpCmp = function | TypeName _  -> false | _-> true

