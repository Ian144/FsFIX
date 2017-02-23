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
 

module CmdLine



// FSharpx.extras does not work with .net 4.6.1 at the time of writing, hence
type ChoiceBuilder() =
    member this.Return a = Choice1Of2 a
    member this.Bind (cx, f) =  match cx with
                                | Choice1Of2 x -> f x
                                | Choice2Of2 x -> Choice2Of2 x
let choose = ChoiceBuilder()        

let Exists pth ff msg = 
    if ff pth then
        Choice1Of2 ""
    else
        Choice2Of2 (sprintf msg pth)

let inputFileExists pth = Exists pth System.IO.File.Exists "FIX xml input file does not exist: %s" 
let outputDirExists pth = Exists pth System.IO.Directory.Exists "output directory path does not exist or is not a directory: %s"


let SafeAccess (arr:'t array) index errMsg = 
    if index < arr.Length then
        Choice1Of2 arr.[index] 
    else
        Choice2Of2 errMsg

let ParseCmdLine (args:string array) = 
        choose {    let! fixXml     = SafeAccess args 0 "both parameters missing"
                    let! outputDir  = SafeAccess args 1 "2nd parameter missing: \"generated code output directory path\""
                    let! _          = inputFileExists fixXml
                    let! _          = outputDirExists outputDir
                    return fixXml, outputDir }