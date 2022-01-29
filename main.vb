'VB版IF97（部分函数） 20211011
'IF97 VB version (partially) 20211011
'本程序用于计算水和水蒸气物理性质，主要参考Bernhard Spang的Water97_v13.xla，另参考CoolProp的IF97，实现了PH和PS的反向计算。
'This program is writen to calculate the physical properties of water and vapor. It mainly refers to Water97_v13.xla by Bernhard Spang and IF97 by CoolProp to realize the reverse calculation of PH and PS. 
'另外简单组合了部分函数，以便使用干度来计算参数。
'In addition, some functions are simply combined to use dryness to calculate parameters. 
'当前代码为VB.net代码，但采用了笨拙的VBA语法，目的是为了兼容VBA，方便在Excel中使用。
'The current code is VB.net code, but the clumsy VBA syntax is used for the purpose of being compatible with VBA and convenient for use in Excel. All "Math." in this article should be removed before using in VBA. 
'在VBA中使用前应将代码中所有的"Math."去掉，删除第一个Module（即整个"ModuleTest"），删除第二个Module的头和尾（即"Module If97"和最后的"End Module"代码）。
'Before using in VBA, you should remove all "Math." in the code, delete the first Module (that is, the entire "ModuleTest"), and delete the head and tail of the second Module (that is, "Module If97" and the last" End Module" code). 
'3125行往前是IF97实现部分，压力单位MPa，温度单位K，其余与Water97_v13.xla相同。函数名采用物理书中通常使用的字母符号，如PT2H意思是已知压力和温度求焓。
'Befour line 3125 is the implementation part of IF97, the pressure unit is MPa, the temperature unit is K, and the rest units are the same as Water97_v13.xla. The function name uses the letter symbols commonly used in physics books. For example, PT2H means the known pressure and temperature to find the enthalpy. 
'3125行往后是API部分，温度单位改为℃，函数名也改成了拼音首字母，如YWH为已知压力、温度求焓。本部分可以自行修改，方便理解使用。
'After line 3125 is the API part, the temperature unit is changed to °C, and the function name is also changed to the initials of pinyin(Phonetic symbols in Mandarin), such as YWH for the known pressure and temperature to find the enthalpy. This part can be modified by yourself to facilitate understanding and use. 
'未对函数做注解，可以参考Water97_v13.xla和IF97的文档。
'The function is not annotated, you can refer to the documentation of Water97_v13.xla and IF97. 

Module ModuleTest
Sub Main()
    Console.Writeline ("Hello World!")
    Console.Writeline ("P2T 1MPa:")
    Console.Writeline (YW(1))
    Console.Writeline ("T2P 100℃:")
    Console.Writeline (WY(100))
    Console.Writeline ("PT2H 3MPa 100℃:")
    Console.Writeline (YWH(3, 100))
End Sub
End Module

Module If97
'区域3饱和参数与WASPCN计算结果有出入，误差不大
'Area 3 saturation parameters are inconsistent with WASPCN calculation results, the deviation is not big 
Private Const Tcrit As Double = 647.096              ' K
Private Const Pcrit As Double = 22.064               ' MPa
Private Const Rhocrit As Double = 322#               ' kg/m^3
Private Const Scrit As Double = 4.41202148223476     ' J/kg-K (needed for backward eqn. in Region 3(a)(b)
Private Const Ttrip As Double = 273.16               ' K
Private Const Ptrip As Double = 0.000611656          ' MPa
Private Const Tmin As Double = 273.15                ' K
Private Const Tmax As Double = 1073.15               ' K
Private Const Pmin As Double = 0.000611213           ' MPa
Private Const Pmax As Double = 100#                  ' MPa
Private Const Rgas As Double = 0.461526              ' kJ/kg-K : mass based!
Private Const MW As Double = 0.018015268             ' kg/mol

Private Const P23min As Double = 16.529164252605     ' MPa (Min Pressure on Region23 boundary curve; Max is Pmax)
Private Const T23min As Double = 623.15              ' K
Private Const T23max As Double = 863.15              ' K

Private ireg1(0 To 33) As Integer
Private jreg1(0 To 33) As Integer
Private nreg1(0 To 33) As Double
Private j0reg2(0 To 8) As Integer
Private n0reg2(0 To 8) As Double
Private ireg2(0 To 42) As Integer
Private jreg2(0 To 42) As Integer
Private nreg2(0 To 42) As Double
Private ireg3(0 To 39) As Integer
Private jreg3(0 To 39) As Integer
Private nreg3(0 To 39) As Double

Private nreg4(0 To 9) As Double
Private nreg23(0 To 4) As Double

Private n0visc(0 To 3) As Double
Private ivisc(0 To 18) As Integer
Private jvisc(0 To 18) As Integer
Private nvisc(0 To 18) As Double
Private n0thcon(0 To 3) As Double
Private nthcon(0 To 4, 0 To 5) As Double

Private ireg1H(0 To 19) As Integer
Private jreg1H(0 To 19) As Integer
Private nreg1H(0 To 19) As Double
Private ireg2aH(0 To 33) As Integer
Private jreg2aH(0 To 33) As Integer
Private nreg2aH(0 To 33) As Double
Private ireg2bH(0 To 37) As Integer
Private jreg2bH(0 To 37) As Integer
Private nreg2bH(0 To 37) As Double
Private ireg2cH(0 To 22) As Integer
Private jreg2cH(0 To 22) As Integer
Private nreg2cH(0 To 22) As Double
Private ireg3aH(0 To 30) As Integer
Private jreg3aH(0 To 30) As Integer
Private nreg3aH(0 To 30) As Double
Private ireg3bH(0 To 32) As Integer
Private jreg3bH(0 To 32) As Integer
Private nreg3bH(0 To 32) As Double

Private ireg1S(0 To 19) As Integer
Private jreg1S(0 To 19) As Integer
Private nreg1S(0 To 19) As Double
Private ireg2aS(0 To 45) As Double
Private jreg2aS(0 To 45) As Integer
Private nreg2aS(0 To 45) As Double
Private ireg2bS(0 To 43) As Integer
Private jreg2bS(0 To 43) As Integer
Private nreg2bS(0 To 43) As Double
Private ireg2cS(0 To 29) As Integer
Private jreg2cS(0 To 29) As Integer
Private nreg2cS(0 To 29) As Double
Private ireg3aS(0 To 32) As Integer
Private jreg3aS(0 To 32) As Integer
Private nreg3aS(0 To 32) As Double
Private ireg3bS(0 To 27) As Integer
Private jreg3bS(0 To 27) As Integer
Private nreg3bS(0 To 27) As Double

Private reg2b2c(0 To 4) As Double
Private reg3a3b(0 To 3) As Double

Sub InitFieldsreg1()
    ireg1(0) = 0
    ireg1(1) = 0
    ireg1(2) = 0
    ireg1(3) = 0
    ireg1(4) = 0
    ireg1(5) = 0
    ireg1(6) = 0
    ireg1(7) = 0
    ireg1(8) = 1
    ireg1(9) = 1
    ireg1(10) = 1
    ireg1(11) = 1
    ireg1(12) = 1
    ireg1(13) = 1
    ireg1(14) = 2
    ireg1(15) = 2
    ireg1(16) = 2
    ireg1(17) = 2
    ireg1(18) = 2
    ireg1(19) = 3
    ireg1(20) = 3
    ireg1(21) = 3
    ireg1(22) = 4
    ireg1(23) = 4
    ireg1(24) = 4
    ireg1(25) = 5
    ireg1(26) = 8
    ireg1(27) = 8
    ireg1(28) = 21
    ireg1(29) = 23
    ireg1(30) = 29
    ireg1(31) = 30
    ireg1(32) = 31
    ireg1(33) = 32
    jreg1(0) = -2
    jreg1(1) = -1
    jreg1(2) = 0
    jreg1(3) = 1
    jreg1(4) = 2
    jreg1(5) = 3
    jreg1(6) = 4
    jreg1(7) = 5
    jreg1(8) = -9
    jreg1(9) = -7
    jreg1(10) = -1
    jreg1(11) = 0
    jreg1(12) = 1
    jreg1(13) = 3
    jreg1(14) = -3
    jreg1(15) = 0
    jreg1(16) = 1
    jreg1(17) = 3
    jreg1(18) = 17
    jreg1(19) = -4
    jreg1(20) = 0
    jreg1(21) = 6
    jreg1(22) = -5
    jreg1(23) = -2
    jreg1(24) = 10
    jreg1(25) = -8
    jreg1(26) = -11
    jreg1(27) = -6
    jreg1(28) = -29
    jreg1(29) = -31
    jreg1(30) = -38
    jreg1(31) = -39
    jreg1(32) = -40
    jreg1(33) = -41
    nreg1(0) = 0.14632971213167
    nreg1(1) = -0.84548187169114
    nreg1(2) = -3.756360367204
    nreg1(3) = 3.3855169168385
    nreg1(4) = -0.95791963387872
    nreg1(5) = 0.15772038513228
    nreg1(6) = -0.016616417199501
    nreg1(7) = 8.1214629983568E-04
    nreg1(8) = 2.8319080123804E-04
    nreg1(9) = -6.0706301565874E-04
    nreg1(10) = -0.018990068218419
    nreg1(11) = -0.032529748770505
    nreg1(12) = -0.021841717175414
    nreg1(13) = -5.283835796993E-05
    nreg1(14) = -4.7184321073267E-04
    nreg1(15) = -3.0001780793026E-04
    nreg1(16) = 4.7661393906987E-05
    nreg1(17) = -4.4141845330846E-06
    nreg1(18) = -7.2694996297594E-16
    nreg1(19) = -3.1679644845054E-05
    nreg1(20) = -2.8270797985312E-06
    nreg1(21) = -8.5205128120103E-10
    nreg1(22) = -2.2425281908E-06
    nreg1(23) = -6.5171222895601E-07
    nreg1(24) = -1.4341729937924E-13
    nreg1(25) = -4.0516996860117E-07
    nreg1(26) = -1.2734301741641E-09
    nreg1(27) = -1.7424871230634E-10
    nreg1(28) = -6.8762131295531E-19
    nreg1(29) = 1.4478307828521E-20
    nreg1(30) = 2.6335781662795E-23
    nreg1(31) = -1.1947622640071E-23
    nreg1(32) = 1.8228094581404E-24
    nreg1(33) = -9.3537087292458E-26
End Sub

Sub InitFieldsreg2()
    j0reg2(0) = 0
    j0reg2(1) = 1
    j0reg2(2) = -5
    j0reg2(3) = -4
    j0reg2(4) = -3
    j0reg2(5) = -2
    j0reg2(6) = -1
    j0reg2(7) = 2
    j0reg2(8) = 3
    n0reg2(0) = -9.6927686500217
    n0reg2(1) = 10.086655968018
    n0reg2(2) = -0.005608791128302
    n0reg2(3) = 0.071452738081455
    n0reg2(4) = -0.40710498223928
    n0reg2(5) = 1.4240819171444
    n0reg2(6) = -4.383951131945
    n0reg2(7) = -0.28408632460772
    n0reg2(8) = 0.021268463753307
    ireg2(0) = 1
    ireg2(1) = 1
    ireg2(2) = 1
    ireg2(3) = 1
    ireg2(4) = 1
    ireg2(5) = 2
    ireg2(6) = 2
    ireg2(7) = 2
    ireg2(8) = 2
    ireg2(9) = 2
    ireg2(10) = 3
    ireg2(11) = 3
    ireg2(12) = 3
    ireg2(13) = 3
    ireg2(14) = 3
    ireg2(15) = 4
    ireg2(16) = 4
    ireg2(17) = 4
    ireg2(18) = 5
    ireg2(19) = 6
    ireg2(20) = 6
    ireg2(21) = 6
    ireg2(22) = 7
    ireg2(23) = 7
    ireg2(24) = 7
    ireg2(25) = 8
    ireg2(26) = 8
    ireg2(27) = 9
    ireg2(28) = 10
    ireg2(29) = 10
    ireg2(30) = 10
    ireg2(31) = 16
    ireg2(32) = 16
    ireg2(33) = 18
    ireg2(34) = 20
    ireg2(35) = 20
    ireg2(36) = 20
    ireg2(37) = 21
    ireg2(38) = 22
    ireg2(39) = 23
    ireg2(40) = 24
    ireg2(41) = 24
    ireg2(42) = 24
    jreg2(0) = 0
    jreg2(1) = 1
    jreg2(2) = 2
    jreg2(3) = 3
    jreg2(4) = 6
    jreg2(5) = 1
    jreg2(6) = 2
    jreg2(7) = 4
    jreg2(8) = 7
    jreg2(9) = 36
    jreg2(10) = 0
    jreg2(11) = 1
    jreg2(12) = 3
    jreg2(13) = 6
    jreg2(14) = 35
    jreg2(15) = 1
    jreg2(16) = 2
    jreg2(17) = 3
    jreg2(18) = 7
    jreg2(19) = 3
    jreg2(20) = 16
    jreg2(21) = 35
    jreg2(22) = 0
    jreg2(23) = 11
    jreg2(24) = 25
    jreg2(25) = 8
    jreg2(26) = 36
    jreg2(27) = 13
    jreg2(28) = 4
    jreg2(29) = 10
    jreg2(30) = 14
    jreg2(31) = 29
    jreg2(32) = 50
    jreg2(33) = 57
    jreg2(34) = 20
    jreg2(35) = 35
    jreg2(36) = 48
    jreg2(37) = 21
    jreg2(38) = 53
    jreg2(39) = 39
    jreg2(40) = 26
    jreg2(41) = 40
    jreg2(42) = 58
    nreg2(0) = -1.7731742473213E-03
    nreg2(1) = -0.017834862292358
    nreg2(2) = -0.045996013696365
    nreg2(3) = -0.057581259083432
    nreg2(4) = -0.05032527872793
    nreg2(5) = -3.3032641670203E-05
    nreg2(6) = -1.8948987516315E-04
    nreg2(7) = -3.9392777243355E-03
    nreg2(8) = -0.043797295650573
    nreg2(9) = -2.6674547914087E-05
    nreg2(10) = 2.0481737692309E-08
    nreg2(11) = 4.3870667284435E-07
    nreg2(12) = -3.227767723857E-05
    nreg2(13) = -1.5033924542148E-03
    nreg2(14) = -0.040668253562649
    nreg2(15) = -7.8847309559367E-10
    nreg2(16) = 1.2790717852285E-08
    nreg2(17) = 4.8225372718507E-07
    nreg2(18) = 2.2922076337661E-06
    nreg2(19) = -1.6714766451061E-11
    nreg2(20) = -2.1171472321355E-03
    nreg2(21) = -23.895741934104
    nreg2(22) = -5.905956432427E-18
    nreg2(23) = -1.2621808899101E-06
    nreg2(24) = -0.038946842435739
    nreg2(25) = 1.1256211360459E-11
    nreg2(26) = -8.2311340897998
    nreg2(27) = 1.9809712802088E-08
    nreg2(28) = 1.0406965210174E-19
    nreg2(29) = -1.0234747095929E-13
    nreg2(30) = -1.0018179379511E-09
    nreg2(31) = -8.0882908646985E-11
    nreg2(32) = 0.10693031879409
    nreg2(33) = -0.33662250574171
    nreg2(34) = 8.9185845355421E-25
    nreg2(35) = 3.0629316876232E-13
    nreg2(36) = -4.2002467698208E-06
    nreg2(37) = -5.9056029685639E-26
    nreg2(38) = 3.7826947613457E-06
    nreg2(39) = -1.2768608934681E-15
    nreg2(40) = 7.3087610595061E-29
    nreg2(41) = 5.5414715350778E-17
    nreg2(42) = -9.436970724121E-07
End Sub

Sub InitFieldsreg3()
    ireg3(0) = 0
    ireg3(1) = 0
    ireg3(2) = 0
    ireg3(3) = 0
    ireg3(4) = 0
    ireg3(5) = 0
    ireg3(6) = 0
    ireg3(7) = 0
    ireg3(8) = 1
    ireg3(9) = 1
    ireg3(10) = 1
    ireg3(11) = 1
    ireg3(12) = 2
    ireg3(13) = 2
    ireg3(14) = 2
    ireg3(15) = 2
    ireg3(16) = 2
    ireg3(17) = 2
    ireg3(18) = 3
    ireg3(19) = 3
    ireg3(20) = 3
    ireg3(21) = 3
    ireg3(22) = 3
    ireg3(23) = 4
    ireg3(24) = 4
    ireg3(25) = 4
    ireg3(26) = 4
    ireg3(27) = 5
    ireg3(28) = 5
    ireg3(29) = 5
    ireg3(30) = 6
    ireg3(31) = 6
    ireg3(32) = 6
    ireg3(33) = 7
    ireg3(34) = 8
    ireg3(35) = 9
    ireg3(36) = 9
    ireg3(37) = 10
    ireg3(38) = 10
    ireg3(39) = 11
    jreg3(0) = 0
    jreg3(1) = 0
    jreg3(2) = 1
    jreg3(3) = 2
    jreg3(4) = 7
    jreg3(5) = 10
    jreg3(6) = 12
    jreg3(7) = 23
    jreg3(8) = 2
    jreg3(9) = 6
    jreg3(10) = 15
    jreg3(11) = 17
    jreg3(12) = 0
    jreg3(13) = 2
    jreg3(14) = 6
    jreg3(15) = 7
    jreg3(16) = 22
    jreg3(17) = 26
    jreg3(18) = 0
    jreg3(19) = 2
    jreg3(20) = 4
    jreg3(21) = 16
    jreg3(22) = 26
    jreg3(23) = 0
    jreg3(24) = 2
    jreg3(25) = 4
    jreg3(26) = 26
    jreg3(27) = 1
    jreg3(28) = 3
    jreg3(29) = 26
    jreg3(30) = 0
    jreg3(31) = 2
    jreg3(32) = 26
    jreg3(33) = 2
    jreg3(34) = 26
    jreg3(35) = 2
    jreg3(36) = 26
    jreg3(37) = 0
    jreg3(38) = 1
    jreg3(39) = 26
    nreg3(0) = 1.0658070028513
    nreg3(1) = -15.732845290239
    nreg3(2) = 20.944396974307
    nreg3(3) = -7.6867707878716
    nreg3(4) = 2.6185947787954
    nreg3(5) = -2.808078114862
    nreg3(6) = 1.2053369696517
    nreg3(7) = -8.4566812812502E-03
    nreg3(8) = -1.2654315477714
    nreg3(9) = -1.1524407806681
    nreg3(10) = 0.88521043984318
    nreg3(11) = -0.64207765181607
    nreg3(12) = 0.38493460186671
    nreg3(13) = -0.85214708824206
    nreg3(14) = 4.8972281541877
    nreg3(15) = -3.0502617256965
    nreg3(16) = 0.039420536879154
    nreg3(17) = 0.12558408424308
    nreg3(18) = -0.2799932969871
    nreg3(19) = 1.389979956946
    nreg3(20) = -2.018991502357
    nreg3(21) = -8.2147637173963E-03
    nreg3(22) = -0.47596035734923
    nreg3(23) = 0.0439840744735
    nreg3(24) = -0.44476435428739
    nreg3(25) = 0.90572070719733
    nreg3(26) = 0.70522450087967
    nreg3(27) = 0.10770512626332
    nreg3(28) = -0.32913623258954
    nreg3(29) = -0.50871062041158
    nreg3(30) = -0.022175400873096
    nreg3(31) = 0.094260751665092
    nreg3(32) = 0.16436278447961
    nreg3(33) = -0.013503372241348
    nreg3(34) = -0.014834345352472
    nreg3(35) = 5.7922953628084E-04
    nreg3(36) = 3.2308904703711E-03
    nreg3(37) = 8.0964802996215E-05
    nreg3(38) = -1.6557679795037E-04
    nreg3(39) = -4.4923899061815E-05
End Sub

Sub InitFieldsreg4()
    nreg4(0) = 1167.0521452767
    nreg4(1) = -724213.16703206
    nreg4(2) = -17.073846940092
    nreg4(3) = 12020.82470247
    nreg4(4) = -3232555.0322333
    nreg4(5) = 14.91510861353
    nreg4(6) = -4823.2657361591
    nreg4(7) = 405113.40542057
    nreg4(8) = -0.23855557567849
    nreg4(9) = 650.17534844798
End Sub

Sub InitFieldsreg23()
    nreg23(0) = 348.05185628969
    nreg23(1) = -1.1671859879975
    nreg23(2) = 1.0192970039326E-03
    nreg23(3) = 572.54459862746
    nreg23(4) = 13.91883977887
End Sub

Sub InitFieldsvisc()
    n0visc(0) = 1#
    n0visc(1) = 0.978197
    n0visc(2) = 0.579829
    n0visc(3) = -0.202354
    ivisc(0) = 0
    ivisc(1) = 0
    ivisc(2) = 0
    ivisc(3) = 0
    ivisc(4) = 1
    ivisc(5) = 1
    ivisc(6) = 1
    ivisc(7) = 1
    ivisc(8) = 2
    ivisc(9) = 2
    ivisc(10) = 2
    ivisc(11) = 3
    ivisc(12) = 3
    ivisc(13) = 3
    ivisc(14) = 3
    ivisc(15) = 4
    ivisc(16) = 4
    ivisc(17) = 5
    ivisc(18) = 6
    jvisc(0) = 0
    jvisc(1) = 1
    jvisc(2) = 4
    jvisc(3) = 5
    jvisc(4) = 0
    jvisc(5) = 1
    jvisc(6) = 2
    jvisc(7) = 3
    jvisc(8) = 0
    jvisc(9) = 1
    jvisc(10) = 2
    jvisc(11) = 0
    jvisc(12) = 1
    jvisc(13) = 2
    jvisc(14) = 3
    jvisc(15) = 0
    jvisc(16) = 3
    jvisc(17) = 1
    jvisc(18) = 3
    nvisc(0) = 0.5132047
    nvisc(1) = 0.3205656
    nvisc(2) = -0.7782567
    nvisc(3) = 0.1885447
    nvisc(4) = 0.2151778
    nvisc(5) = 0.7317883
    nvisc(6) = 1.241044
    nvisc(7) = 1.476783
    nvisc(8) = -0.2818107
    nvisc(9) = -1.070786
    nvisc(10) = -1.263184
    nvisc(11) = 0.1778064
    nvisc(12) = 0.460504
    nvisc(13) = 0.2340379
    nvisc(14) = -0.4924179
    nvisc(15) = -0.0417661
    nvisc(16) = 0.1600435
    nvisc(17) = -0.01578386
    nvisc(18) = -0.003629481
End Sub

Sub InitFieldsthcon()
    n0thcon(0) = 1#
    n0thcon(1) = 6.978267
    n0thcon(2) = 2.599096
    n0thcon(3) = -0.998254
    nthcon(0, 0) = 1.3293046
    nthcon(0, 1) = -0.40452437
    nthcon(0, 2) = 0.2440949
    nthcon(0, 3) = 0.018660751
    nthcon(0, 4) = -0.12961068
    nthcon(0, 5) = 0.044809953
    nthcon(1, 0) = 1.7018363
    nthcon(1, 1) = -2.2156845
    nthcon(1, 2) = 1.6511057
    nthcon(1, 3) = -0.76736002
    nthcon(1, 4) = 0.37283344
    nthcon(1, 5) = -0.1120316
    nthcon(2, 0) = 5.2246158
    nthcon(2, 1) = -10.124111
    nthcon(2, 2) = 4.9874687
    nthcon(2, 3) = -0.27297694
    nthcon(2, 4) = -0.43083393
    nthcon(2, 5) = 0.13333849
    nthcon(3, 0) = 8.7127675
    nthcon(3, 1) = -9.5000611
    nthcon(3, 2) = 4.3786606
    nthcon(3, 3) = -0.91783782
    nthcon(3, 4) = 0#
    nthcon(3, 5) = 0#
    nthcon(4, 0) = -1.8525999
    nthcon(4, 1) = 0.9340469
    nthcon(4, 2) = 0#
    nthcon(4, 3) = 0#
    nthcon(4, 4) = 0#
    nthcon(4, 5) = 0#
End Sub

Sub InitFieldsreg1H()
    ireg1H(0) = 0
    ireg1H(1) = 0
    ireg1H(2) = 0
    ireg1H(3) = 0
    ireg1H(4) = 0
    ireg1H(5) = 0
    ireg1H(6) = 1
    ireg1H(7) = 1
    ireg1H(8) = 1
    ireg1H(9) = 1
    ireg1H(10) = 1
    ireg1H(11) = 1
    ireg1H(12) = 1
    ireg1H(13) = 2
    ireg1H(14) = 2
    ireg1H(15) = 3
    ireg1H(16) = 3
    ireg1H(17) = 4
    ireg1H(18) = 5
    ireg1H(19) = 6
    jreg1H(0) = 0
    jreg1H(1) = 1
    jreg1H(2) = 2
    jreg1H(3) = 6
    jreg1H(4) = 22
    jreg1H(5) = 32
    jreg1H(6) = 0
    jreg1H(7) = 1
    jreg1H(8) = 2
    jreg1H(9) = 3
    jreg1H(10) = 4
    jreg1H(11) = 10
    jreg1H(12) = 32
    jreg1H(13) = 10
    jreg1H(14) = 32
    jreg1H(15) = 10
    jreg1H(16) = 32
    jreg1H(17) = 32
    jreg1H(18) = 32
    jreg1H(19) = 32
    nreg1H(0) = -238.72489924521
    nreg1H(1) = 404.21188637945
    nreg1H(2) = 113.49746881718
    nreg1H(3) = -5.8457616048039
    nreg1H(4) = -1.528548241314E-04
    nreg1H(5) = -1.0866707695377E-06
    nreg1H(6) = -13.391744872602
    nreg1H(7) = 43.211039183559
    nreg1H(8) = -54.010067170506
    nreg1H(9) = 30.535892203916
    nreg1H(10) = -6.5964749423638
    nreg1H(11) = 9.3965400878363E-03
    nreg1H(12) = 1.157364750534E-07
    nreg1H(13) = -2.5858641282073E-05
    nreg1H(14) = -4.0644363084799E-09
    nreg1H(15) = 6.6456186191635E-08
    nreg1H(16) = 8.0670734103027E-11
    nreg1H(17) = -9.3477771213947E-13
    nreg1H(18) = 5.8265442020601E-15
    nreg1H(19) = -1.5020185953503E-17
End Sub

Sub InitFieldsreg2aH()
    ireg2aH(0) = 0
    ireg2aH(1) = 0
    ireg2aH(2) = 0
    ireg2aH(3) = 0
    ireg2aH(4) = 0
    ireg2aH(5) = 0
    ireg2aH(6) = 1
    ireg2aH(7) = 1
    ireg2aH(8) = 1
    ireg2aH(9) = 1
    ireg2aH(10) = 1
    ireg2aH(11) = 1
    ireg2aH(12) = 1
    ireg2aH(13) = 1
    ireg2aH(14) = 1
    ireg2aH(15) = 2
    ireg2aH(16) = 2
    ireg2aH(17) = 2
    ireg2aH(18) = 2
    ireg2aH(19) = 2
    ireg2aH(20) = 2
    ireg2aH(21) = 2
    ireg2aH(22) = 2
    ireg2aH(23) = 3
    ireg2aH(24) = 3
    ireg2aH(25) = 4
    ireg2aH(26) = 4
    ireg2aH(27) = 4
    ireg2aH(28) = 5
    ireg2aH(29) = 5
    ireg2aH(30) = 5
    ireg2aH(31) = 6
    ireg2aH(32) = 6
    ireg2aH(33) = 7
    jreg2aH(0) = 0
    jreg2aH(1) = 1
    jreg2aH(2) = 2
    jreg2aH(3) = 3
    jreg2aH(4) = 7
    jreg2aH(5) = 20
    jreg2aH(6) = 0
    jreg2aH(7) = 1
    jreg2aH(8) = 2
    jreg2aH(9) = 3
    jreg2aH(10) = 7
    jreg2aH(11) = 9
    jreg2aH(12) = 11
    jreg2aH(13) = 18
    jreg2aH(14) = 44
    jreg2aH(15) = 0
    jreg2aH(16) = 2
    jreg2aH(17) = 7
    jreg2aH(18) = 36
    jreg2aH(19) = 38
    jreg2aH(20) = 40
    jreg2aH(21) = 42
    jreg2aH(22) = 44
    jreg2aH(23) = 24
    jreg2aH(24) = 44
    jreg2aH(25) = 12
    jreg2aH(26) = 32
    jreg2aH(27) = 44
    jreg2aH(28) = 32
    jreg2aH(29) = 36
    jreg2aH(30) = 42
    jreg2aH(31) = 34
    jreg2aH(32) = 44
    jreg2aH(33) = 28
    nreg2aH(0) = 1089.8952318288
    nreg2aH(1) = 849.51654495535
    nreg2aH(2) = -107.81748091826
    nreg2aH(3) = 33.153654801263
    nreg2aH(4) = -7.4232016790248
    nreg2aH(5) = 11.765048724356
    nreg2aH(6) = 1.844574935579
    nreg2aH(7) = -4.1792700549624
    nreg2aH(8) = 6.2478196935812
    nreg2aH(9) = -17.344563108114
    nreg2aH(10) = -200.58176862096
    nreg2aH(11) = 271.96065473796
    nreg2aH(12) = -455.11318285818
    nreg2aH(13) = 3091.9688604755
    nreg2aH(14) = 252266.40357872
    nreg2aH(15) = -6.1707422868339E-03
    nreg2aH(16) = -0.31078046629583
    nreg2aH(17) = 11.670873077107
    nreg2aH(18) = 128127984.04046
    nreg2aH(19) = -985549096.23276
    nreg2aH(20) = 2822454697.3002
    nreg2aH(21) = -3594897141.0703
    nreg2aH(22) = 1722734991.3197
    nreg2aH(23) = -13551.334240775
    nreg2aH(24) = 12848734.66465
    nreg2aH(25) = 1.3865724283226
    nreg2aH(26) = 235988.32556514
    nreg2aH(27) = -13105236.545054
    nreg2aH(28) = 7399.9835474766
    nreg2aH(29) = -551966.9703006
    nreg2aH(30) = 3715408.5996233
    nreg2aH(31) = 19127.72923966
    nreg2aH(32) = -415351.64835634
    nreg2aH(33) = -62.459855192507
End Sub

Sub InitFieldsreg2bH()
    ireg2bH(0) = 0
    ireg2bH(1) = 0
    ireg2bH(2) = 0
    ireg2bH(3) = 0
    ireg2bH(4) = 0
    ireg2bH(5) = 0
    ireg2bH(6) = 0
    ireg2bH(7) = 0
    ireg2bH(8) = 1
    ireg2bH(9) = 1
    ireg2bH(10) = 1
    ireg2bH(11) = 1
    ireg2bH(12) = 1
    ireg2bH(13) = 1
    ireg2bH(14) = 1
    ireg2bH(15) = 1
    ireg2bH(16) = 2
    ireg2bH(17) = 2
    ireg2bH(18) = 2
    ireg2bH(19) = 2
    ireg2bH(20) = 3
    ireg2bH(21) = 3
    ireg2bH(22) = 3
    ireg2bH(23) = 3
    ireg2bH(24) = 4
    ireg2bH(25) = 4
    ireg2bH(26) = 4
    ireg2bH(27) = 4
    ireg2bH(28) = 4
    ireg2bH(29) = 4
    ireg2bH(30) = 5
    ireg2bH(31) = 5
    ireg2bH(32) = 5
    ireg2bH(33) = 6
    ireg2bH(34) = 7
    ireg2bH(35) = 7
    ireg2bH(36) = 9
    ireg2bH(37) = 9
    jreg2bH(0) = 0
    jreg2bH(1) = 1
    jreg2bH(2) = 2
    jreg2bH(3) = 12
    jreg2bH(4) = 18
    jreg2bH(5) = 24
    jreg2bH(6) = 28
    jreg2bH(7) = 40
    jreg2bH(8) = 0
    jreg2bH(9) = 2
    jreg2bH(10) = 6
    jreg2bH(11) = 12
    jreg2bH(12) = 18
    jreg2bH(13) = 24
    jreg2bH(14) = 28
    jreg2bH(15) = 40
    jreg2bH(16) = 2
    jreg2bH(17) = 8
    jreg2bH(18) = 18
    jreg2bH(19) = 40
    jreg2bH(20) = 1
    jreg2bH(21) = 2
    jreg2bH(22) = 12
    jreg2bH(23) = 24
    jreg2bH(24) = 2
    jreg2bH(25) = 12
    jreg2bH(26) = 18
    jreg2bH(27) = 24
    jreg2bH(28) = 28
    jreg2bH(29) = 40
    jreg2bH(30) = 18
    jreg2bH(31) = 24
    jreg2bH(32) = 40
    jreg2bH(33) = 28
    jreg2bH(34) = 2
    jreg2bH(35) = 28
    jreg2bH(36) = 1
    jreg2bH(37) = 40
    nreg2bH(0) = 1489.5041079516
    nreg2bH(1) = 743.07798314034
    nreg2bH(2) = -97.708318797837
    nreg2bH(3) = 2.4742464705674
    nreg2bH(4) = -0.63281320016026
    nreg2bH(5) = 1.1385952129658
    nreg2bH(6) = -0.47811863648625
    nreg2bH(7) = 8.5208123431544E-03
    nreg2bH(8) = 0.93747147377932
    nreg2bH(9) = 3.3593118604916
    nreg2bH(10) = 3.3809355601454
    nreg2bH(11) = 0.16844539671904
    nreg2bH(12) = 0.73875745236695
    nreg2bH(13) = -0.47128737436186
    nreg2bH(14) = 0.15020273139707
    nreg2bH(15) = -0.002176411421975
    nreg2bH(16) = -0.021810755324761
    nreg2bH(17) = -0.10829784403677
    nreg2bH(18) = -0.046333324635812
    nreg2bH(19) = 7.1280351959551E-05
    nreg2bH(20) = 1.1032831789999E-04
    nreg2bH(21) = 1.8955248387902E-04
    nreg2bH(22) = 3.0891541160537E-03
    nreg2bH(23) = 1.3555504554949E-03
    nreg2bH(24) = 2.8640237477456E-07
    nreg2bH(25) = -1.0779857357512E-05
    nreg2bH(26) = -7.6462712454814E-05
    nreg2bH(27) = 1.4052392818316E-05
    nreg2bH(28) = -3.1083814331434E-05
    nreg2bH(29) = -1.0302738212103E-06
    nreg2bH(30) = 2.821728163504E-07
    nreg2bH(31) = 1.2704902271945E-06
    nreg2bH(32) = 7.3803353468292E-08
    nreg2bH(33) = -1.1030139238909E-08
    nreg2bH(34) = -8.1456365207833E-14
    nreg2bH(35) = -2.5180545682962E-11
    nreg2bH(36) = -1.7565233969407E-18
    nreg2bH(37) = 8.6934156344163E-15
End Sub

Sub InitFieldsreg2cH()
    ireg2cH(0) = -7
    ireg2cH(1) = -7
    ireg2cH(2) = -6
    ireg2cH(3) = -6
    ireg2cH(4) = -5
    ireg2cH(5) = -5
    ireg2cH(6) = -2
    ireg2cH(7) = -2
    ireg2cH(8) = -1
    ireg2cH(9) = -1
    ireg2cH(10) = 0
    ireg2cH(11) = 0
    ireg2cH(12) = 1
    ireg2cH(13) = 1
    ireg2cH(14) = 2
    ireg2cH(15) = 6
    ireg2cH(16) = 6
    ireg2cH(17) = 6
    ireg2cH(18) = 6
    ireg2cH(19) = 6
    ireg2cH(20) = 6
    ireg2cH(21) = 6
    ireg2cH(22) = 6
    jreg2cH(0) = 0
    jreg2cH(1) = 4
    jreg2cH(2) = 0
    jreg2cH(3) = 2
    jreg2cH(4) = 0
    jreg2cH(5) = 2
    jreg2cH(6) = 0
    jreg2cH(7) = 1
    jreg2cH(8) = 0
    jreg2cH(9) = 2
    jreg2cH(10) = 0
    jreg2cH(11) = 1
    jreg2cH(12) = 4
    jreg2cH(13) = 8
    jreg2cH(14) = 4
    jreg2cH(15) = 0
    jreg2cH(16) = 1
    jreg2cH(17) = 4
    jreg2cH(18) = 10
    jreg2cH(19) = 12
    jreg2cH(20) = 16
    jreg2cH(21) = 20
    jreg2cH(22) = 22
    nreg2cH(0) = -3236839855524.2
    nreg2cH(1) = 7326335090218.1
    nreg2cH(2) = 358250899454.47
    nreg2cH(3) = -583401318515.9
    nreg2cH(4) = -10783068217.47
    nreg2cH(5) = 20825544563.171
    nreg2cH(6) = 610747.83564516
    nreg2cH(7) = 859777.2253558
    nreg2cH(8) = -25745.72360417
    nreg2cH(9) = 31081.088422714
    nreg2cH(10) = 1208.2315865936
    nreg2cH(11) = 482.19755109255
    nreg2cH(12) = 3.7966001272486
    nreg2cH(13) = -10.842984880077
    nreg2cH(14) = -0.04536417267666
    nreg2cH(15) = 1.4559115658698E-13
    nreg2cH(16) = 1.126159740723E-12
    nreg2cH(17) = -1.7804982240686E-11
    nreg2cH(18) = 1.2324579690832E-07
    nreg2cH(19) = -1.1606921130984E-06
    nreg2cH(20) = 2.7846367088554E-05
    nreg2cH(21) = -5.9270038474176E-04
    nreg2cH(22) = 1.2918582991878E-03
End Sub

Sub InitFieldsreg3aH()
    ireg3aH(0) = -12
    ireg3aH(1) = -12
    ireg3aH(2) = -12
    ireg3aH(3) = -12
    ireg3aH(4) = -12
    ireg3aH(5) = -12
    ireg3aH(6) = -12
    ireg3aH(7) = -12
    ireg3aH(8) = -10
    ireg3aH(9) = -10
    ireg3aH(10) = -10
    ireg3aH(11) = -8
    ireg3aH(12) = -8
    ireg3aH(13) = -8
    ireg3aH(14) = -8
    ireg3aH(15) = -5
    ireg3aH(16) = -3
    ireg3aH(17) = -2
    ireg3aH(18) = -2
    ireg3aH(19) = -2
    ireg3aH(20) = -1
    ireg3aH(21) = -1
    ireg3aH(22) = 0
    ireg3aH(23) = 0
    ireg3aH(24) = 1
    ireg3aH(25) = 3
    ireg3aH(26) = 3
    ireg3aH(27) = 4
    ireg3aH(28) = 4
    ireg3aH(29) = 10
    ireg3aH(30) = 12
    jreg3aH(0) = 0
    jreg3aH(1) = 1
    jreg3aH(2) = 2
    jreg3aH(3) = 6
    jreg3aH(4) = 14
    jreg3aH(5) = 16
    jreg3aH(6) = 20
    jreg3aH(7) = 22
    jreg3aH(8) = 1
    jreg3aH(9) = 5
    jreg3aH(10) = 12
    jreg3aH(11) = 0
    jreg3aH(12) = 2
    jreg3aH(13) = 4
    jreg3aH(14) = 10
    jreg3aH(15) = 2
    jreg3aH(16) = 0
    jreg3aH(17) = 1
    jreg3aH(18) = 3
    jreg3aH(19) = 4
    jreg3aH(20) = 0
    jreg3aH(21) = 2
    jreg3aH(22) = 0
    jreg3aH(23) = 1
    jreg3aH(24) = 1
    jreg3aH(25) = 0
    jreg3aH(26) = 1
    jreg3aH(27) = 0
    jreg3aH(28) = 3
    jreg3aH(29) = 4
    jreg3aH(30) = 5
    nreg3aH(0) = -1.33645667811215E-07
    nreg3aH(1) = 4.55912656802978E-06
    nreg3aH(2) = -1.46294640700979E-05
    nreg3aH(3) = 6.3934131297008E-03
    nreg3aH(4) = 372.783927268847
    nreg3aH(5) = -7186.54377460447
    nreg3aH(6) = 573494.7521034
    nreg3aH(7) = -2675693.29111439
    nreg3aH(8) = -3.34066283302614E-05
    nreg3aH(9) = -2.45479214069597E-02
    nreg3aH(10) = 47.8087847764996
    nreg3aH(11) = 7.64664131818904E-06
    nreg3aH(12) = 1.28350627676972E-03
    nreg3aH(13) = 1.71219081377331E-02
    nreg3aH(14) = -8.51007304583213
    nreg3aH(15) = -1.36513461629781E-02
    nreg3aH(16) = -3.84460997596657E-06
    nreg3aH(17) = 3.37423807911655E-03
    nreg3aH(18) = -0.551624873066791
    nreg3aH(19) = 0.72920227710747
    nreg3aH(20) = -9.92522757376041E-03
    nreg3aH(21) = -0.119308831407288
    nreg3aH(22) = 0.793929190615421
    nreg3aH(23) = 0.454270731799386
    nreg3aH(24) = 0.20999859125991
    nreg3aH(25) = -6.42109823904738E-03
    nreg3aH(26) = -0.023515586860454
    nreg3aH(27) = 2.52233108341612E-03
    nreg3aH(28) = -7.64885133368119E-03
    nreg3aH(29) = 1.36176427574291E-02
    nreg3aH(30) = -1.33027883575669E-02
End Sub

Sub InitFieldsreg3bH()
    ireg3bH(0) = -12
    ireg3bH(1) = -12
    ireg3bH(2) = -10
    ireg3bH(3) = -10
    ireg3bH(4) = -10
    ireg3bH(5) = -10
    ireg3bH(6) = -10
    ireg3bH(7) = -8
    ireg3bH(8) = -8
    ireg3bH(9) = -8
    ireg3bH(10) = -8
    ireg3bH(11) = -8
    ireg3bH(12) = -6
    ireg3bH(13) = -6
    ireg3bH(14) = -6
    ireg3bH(15) = -4
    ireg3bH(16) = -4
    ireg3bH(17) = -3
    ireg3bH(18) = -2
    ireg3bH(19) = -2
    ireg3bH(20) = -1
    ireg3bH(21) = -1
    ireg3bH(22) = -1
    ireg3bH(23) = -1
    ireg3bH(24) = -1
    ireg3bH(25) = -1
    ireg3bH(26) = 0
    ireg3bH(27) = 0
    ireg3bH(28) = 1
    ireg3bH(29) = 3
    ireg3bH(30) = 5
    ireg3bH(31) = 6
    ireg3bH(32) = 8
    jreg3bH(0) = 0
    jreg3bH(1) = 1
    jreg3bH(2) = 0
    jreg3bH(3) = 1
    jreg3bH(4) = 5
    jreg3bH(5) = 10
    jreg3bH(6) = 12
    jreg3bH(7) = 0
    jreg3bH(8) = 1
    jreg3bH(9) = 2
    jreg3bH(10) = 4
    jreg3bH(11) = 10
    jreg3bH(12) = 0
    jreg3bH(13) = 1
    jreg3bH(14) = 2
    jreg3bH(15) = 0
    jreg3bH(16) = 1
    jreg3bH(17) = 5
    jreg3bH(18) = 0
    jreg3bH(19) = 4
    jreg3bH(20) = 2
    jreg3bH(21) = 4
    jreg3bH(22) = 6
    jreg3bH(23) = 10
    jreg3bH(24) = 14
    jreg3bH(25) = 16
    jreg3bH(26) = 0
    jreg3bH(27) = 2
    jreg3bH(28) = 1
    jreg3bH(29) = 1
    jreg3bH(30) = 1
    jreg3bH(31) = 1
    jreg3bH(32) = 1
    nreg3bH(0) = 3.2325457364492E-05
    nreg3bH(1) = -1.27575556587181E-04
    nreg3bH(2) = -4.75851877356068E-04
    nreg3bH(3) = 1.56183014181602E-03
    nreg3bH(4) = 0.105724860113781
    nreg3bH(5) = -85.8514221132534
    nreg3bH(6) = 724.140095480911
    nreg3bH(7) = 2.96475810273257E-03
    nreg3bH(8) = -5.92721983365988E-03
    nreg3bH(9) = -1.26305422818666E-02
    nreg3bH(10) = -0.115716196364853
    nreg3bH(11) = 84.9000969739595
    nreg3bH(12) = -1.08602260086615E-02
    nreg3bH(13) = 1.54304475328851E-02
    nreg3bH(14) = 7.50455441524466E-02
    nreg3bH(15) = 2.52520973612982E-02
    nreg3bH(16) = -6.02507901232996E-02
    nreg3bH(17) = -3.07622221350501
    nreg3bH(18) = -5.74011959864879E-02
    nreg3bH(19) = 5.03471360939849
    nreg3bH(20) = -0.925081888584834
    nreg3bH(21) = 3.91733882917546
    nreg3bH(22) = -77.314600713019
    nreg3bH(23) = 9493.08762098587
    nreg3bH(24) = -1410437.19679409
    nreg3bH(25) = 8491662.30819026
    nreg3bH(26) = 0.861095729446704
    nreg3bH(27) = 0.32334644281172
    nreg3bH(28) = 0.873281936020439
    nreg3bH(29) = -0.436653048526683
    nreg3bH(30) = 0.286596714529479
    nreg3bH(31) = -0.131778331276228
    nreg3bH(32) = 6.76682064330275E-03
End Sub

Sub InitFieldsreg1S()
    ireg1S(0) = 0
    ireg1S(1) = 0
    ireg1S(2) = 0
    ireg1S(3) = 0
    ireg1S(4) = 0
    ireg1S(5) = 0
    ireg1S(6) = 1
    ireg1S(7) = 1
    ireg1S(8) = 1
    ireg1S(9) = 1
    ireg1S(10) = 1
    ireg1S(11) = 1
    ireg1S(12) = 2
    ireg1S(13) = 2
    ireg1S(14) = 2
    ireg1S(15) = 2
    ireg1S(16) = 2
    ireg1S(17) = 3
    ireg1S(18) = 3
    ireg1S(19) = 4
    jreg1S(0) = 0
    jreg1S(1) = 1
    jreg1S(2) = 2
    jreg1S(3) = 3
    jreg1S(4) = 11
    jreg1S(5) = 31
    jreg1S(6) = 0
    jreg1S(7) = 1
    jreg1S(8) = 2
    jreg1S(9) = 3
    jreg1S(10) = 12
    jreg1S(11) = 31
    jreg1S(12) = 0
    jreg1S(13) = 1
    jreg1S(14) = 2
    jreg1S(15) = 9
    jreg1S(16) = 31
    jreg1S(17) = 10
    jreg1S(18) = 32
    jreg1S(19) = 32
    nreg1S(0) = 174.78268058307
    nreg1S(1) = 34.806930892873
    nreg1S(2) = 6.5292584978455
    nreg1S(3) = 0.33039981775489
    nreg1S(4) = -1.9281382923196E-07
    nreg1S(5) = -2.4909197244573E-23
    nreg1S(6) = -0.26107636489332
    nreg1S(7) = 0.22592965981586
    nreg1S(8) = -0.064256463395226
    nreg1S(9) = 7.8876289270526E-03
    nreg1S(10) = 3.5672110607366E-10
    nreg1S(11) = 1.7332496994895E-24
    nreg1S(12) = 5.6608900654837E-04
    nreg1S(13) = -3.2635483139717E-04
    nreg1S(14) = 4.4778286690632E-05
    nreg1S(15) = -5.1322156908507E-10
    nreg1S(16) = -4.2522657042207E-26
    nreg1S(17) = 2.6400441360689E-13
    nreg1S(18) = 7.8124600459723E-29
    nreg1S(19) = -3.0732199903668E-31
End Sub

Sub InitFieldsreg2aS()
    ireg2aS(0) = -1.5
    ireg2aS(1) = -1.5
    ireg2aS(2) = -1.5
    ireg2aS(3) = -1.5
    ireg2aS(4) = -1.5
    ireg2aS(5) = -1.5
    ireg2aS(6) = -1.25
    ireg2aS(7) = -1.25
    ireg2aS(8) = -1.25
    ireg2aS(9) = -1
    ireg2aS(10) = -1
    ireg2aS(11) = -1
    ireg2aS(12) = -1
    ireg2aS(13) = -1
    ireg2aS(14) = -1
    ireg2aS(15) = -0.75
    ireg2aS(16) = -0.75
    ireg2aS(17) = -0.5
    ireg2aS(18) = -0.5
    ireg2aS(19) = -0.5
    ireg2aS(20) = -0.5
    ireg2aS(21) = -0.25
    ireg2aS(22) = -0.25
    ireg2aS(23) = -0.25
    ireg2aS(24) = -0.25
    ireg2aS(25) = 0.25
    ireg2aS(26) = 0.25
    ireg2aS(27) = 0.25
    ireg2aS(28) = 0.25
    ireg2aS(29) = 0.5
    ireg2aS(30) = 0.5
    ireg2aS(31) = 0.5
    ireg2aS(32) = 0.5
    ireg2aS(33) = 0.5
    ireg2aS(34) = 0.5
    ireg2aS(35) = 0.5
    ireg2aS(36) = 0.75
    ireg2aS(37) = 0.75
    ireg2aS(38) = 0.75
    ireg2aS(39) = 0.75
    ireg2aS(40) = 1
    ireg2aS(41) = 1
    ireg2aS(42) = 1.25
    ireg2aS(43) = 1.25
    ireg2aS(44) = 1.5
    ireg2aS(45) = 1.5
    jreg2aS(0) = -24
    jreg2aS(1) = -23
    jreg2aS(2) = -19
    jreg2aS(3) = -13
    jreg2aS(4) = -11
    jreg2aS(5) = -10
    jreg2aS(6) = -19
    jreg2aS(7) = -15
    jreg2aS(8) = -6
    jreg2aS(9) = -26
    jreg2aS(10) = -21
    jreg2aS(11) = -17
    jreg2aS(12) = -16
    jreg2aS(13) = -9
    jreg2aS(14) = -8
    jreg2aS(15) = -15
    jreg2aS(16) = -14
    jreg2aS(17) = -26
    jreg2aS(18) = -13
    jreg2aS(19) = -9
    jreg2aS(20) = -7
    jreg2aS(21) = -27
    jreg2aS(22) = -25
    jreg2aS(23) = -11
    jreg2aS(24) = -6
    jreg2aS(25) = 1
    jreg2aS(26) = 4
    jreg2aS(27) = 8
    jreg2aS(28) = 11
    jreg2aS(29) = 0
    jreg2aS(30) = 1
    jreg2aS(31) = 5
    jreg2aS(32) = 6
    jreg2aS(33) = 10
    jreg2aS(34) = 14
    jreg2aS(35) = 16
    jreg2aS(36) = 0
    jreg2aS(37) = 4
    jreg2aS(38) = 9
    jreg2aS(39) = 17
    jreg2aS(40) = 7
    jreg2aS(41) = 18
    jreg2aS(42) = 3
    jreg2aS(43) = 15
    jreg2aS(44) = 5
    jreg2aS(45) = 18
    nreg2aS(0) = -392359.83861984
    nreg2aS(1) = 515265.7382727
    nreg2aS(2) = 40482.443161048
    nreg2aS(3) = -321.93790923902
    nreg2aS(4) = 96.961424218694
    nreg2aS(5) = -22.867846371773
    nreg2aS(6) = -449429.14124357
    nreg2aS(7) = -5011.8336020166
    nreg2aS(8) = 0.35684463560015
    nreg2aS(9) = 44235.33584819
    nreg2aS(10) = -13673.388811708
    nreg2aS(11) = 421632.60207864
    nreg2aS(12) = 22516.925837475
    nreg2aS(13) = 474.42144865646
    nreg2aS(14) = -149.31130797647
    nreg2aS(15) = -197811.26320452
    nreg2aS(16) = -23554.39947076
    nreg2aS(17) = -19070.616302076
    nreg2aS(18) = 55375.669883164
    nreg2aS(19) = 3829.3691437363
    nreg2aS(20) = -603.91860580567
    nreg2aS(21) = 1936.3102620331
    nreg2aS(22) = 4266.064369861
    nreg2aS(23) = -5978.0638872718
    nreg2aS(24) = -704.01463926862
    nreg2aS(25) = 338.36784107553
    nreg2aS(26) = 20.862786635187
    nreg2aS(27) = 0.033834172656196
    nreg2aS(28) = -4.3124428414893E-05
    nreg2aS(29) = 166.53791356412
    nreg2aS(30) = -139.86292055898
    nreg2aS(31) = -0.78849547999872
    nreg2aS(32) = 0.072132411753872
    nreg2aS(33) = -5.9754839398283E-03
    nreg2aS(34) = -1.2141358953904E-05
    nreg2aS(35) = 2.3227096733871E-07
    nreg2aS(36) = -10.538463566194
    nreg2aS(37) = 2.0718925496502
    nreg2aS(38) = -0.072193155260427
    nreg2aS(39) = 2.074988708112E-07
    nreg2aS(40) = -0.018340657911379
    nreg2aS(41) = 2.9036272348696E-07
    nreg2aS(42) = 0.21037527893619
    nreg2aS(43) = 2.5681239729999E-04
    nreg2aS(44) = -0.012799002933781
    nreg2aS(45) = -8.2198102652018E-06
End Sub

Sub InitFieldsreg2bS()
    ireg2bS(0) = -6
    ireg2bS(1) = -6
    ireg2bS(2) = -5
    ireg2bS(3) = -5
    ireg2bS(4) = -4
    ireg2bS(5) = -4
    ireg2bS(6) = -4
    ireg2bS(7) = -3
    ireg2bS(8) = -3
    ireg2bS(9) = -3
    ireg2bS(10) = -3
    ireg2bS(11) = -2
    ireg2bS(12) = -2
    ireg2bS(13) = -2
    ireg2bS(14) = -2
    ireg2bS(15) = -1
    ireg2bS(16) = -1
    ireg2bS(17) = -1
    ireg2bS(18) = -1
    ireg2bS(19) = -1
    ireg2bS(20) = 0
    ireg2bS(21) = 0
    ireg2bS(22) = 0
    ireg2bS(23) = 0
    ireg2bS(24) = 0
    ireg2bS(25) = 0
    ireg2bS(26) = 0
    ireg2bS(27) = 1
    ireg2bS(28) = 1
    ireg2bS(29) = 1
    ireg2bS(30) = 1
    ireg2bS(31) = 1
    ireg2bS(32) = 1
    ireg2bS(33) = 2
    ireg2bS(34) = 2
    ireg2bS(35) = 2
    ireg2bS(36) = 3
    ireg2bS(37) = 3
    ireg2bS(38) = 3
    ireg2bS(39) = 4
    ireg2bS(40) = 4
    ireg2bS(41) = 5
    ireg2bS(42) = 5
    ireg2bS(43) = 5
    jreg2bS(0) = 0
    jreg2bS(1) = 11
    jreg2bS(2) = 0
    jreg2bS(3) = 11
    jreg2bS(4) = 0
    jreg2bS(5) = 1
    jreg2bS(6) = 11
    jreg2bS(7) = 0
    jreg2bS(8) = 1
    jreg2bS(9) = 11
    jreg2bS(10) = 12
    jreg2bS(11) = 0
    jreg2bS(12) = 1
    jreg2bS(13) = 6
    jreg2bS(14) = 10
    jreg2bS(15) = 0
    jreg2bS(16) = 1
    jreg2bS(17) = 5
    jreg2bS(18) = 8
    jreg2bS(19) = 9
    jreg2bS(20) = 0
    jreg2bS(21) = 1
    jreg2bS(22) = 2
    jreg2bS(23) = 4
    jreg2bS(24) = 5
    jreg2bS(25) = 6
    jreg2bS(26) = 9
    jreg2bS(27) = 0
    jreg2bS(28) = 1
    jreg2bS(29) = 2
    jreg2bS(30) = 3
    jreg2bS(31) = 7
    jreg2bS(32) = 8
    jreg2bS(33) = 0
    jreg2bS(34) = 1
    jreg2bS(35) = 5
    jreg2bS(36) = 0
    jreg2bS(37) = 1
    jreg2bS(38) = 3
    jreg2bS(39) = 0
    jreg2bS(40) = 1
    jreg2bS(41) = 0
    jreg2bS(42) = 1
    jreg2bS(43) = 2
    nreg2bS(0) = 316876.65083497
    nreg2bS(1) = 20.864175881858
    nreg2bS(2) = -398593.99803599
    nreg2bS(3) = -21.816058518877
    nreg2bS(4) = 223697.85194242
    nreg2bS(5) = -2784.1703445817
    nreg2bS(6) = 9.920743607148
    nreg2bS(7) = -75197.512299157
    nreg2bS(8) = 2970.8605951158
    nreg2bS(9) = -3.4406878548526
    nreg2bS(10) = 0.38815564249115
    nreg2bS(11) = 17511.29508575
    nreg2bS(12) = -1423.7112854449
    nreg2bS(13) = 1.0943803364167
    nreg2bS(14) = 0.89971619308495
    nreg2bS(15) = -3375.9740098958
    nreg2bS(16) = 471.62885818355
    nreg2bS(17) = -1.9188241993679
    nreg2bS(18) = 0.41078580492196
    nreg2bS(19) = -0.33465378172097
    nreg2bS(20) = 1387.0034777505
    nreg2bS(21) = -406.63326195838
    nreg2bS(22) = 41.72734715961
    nreg2bS(23) = 2.1932549434532
    nreg2bS(24) = -1.0320050009077
    nreg2bS(25) = 0.35882943516703
    nreg2bS(26) = 5.2511453726066E-03
    nreg2bS(27) = 12.838916450705
    nreg2bS(28) = -2.8642437219381
    nreg2bS(29) = 0.56912683664855
    nreg2bS(30) = -0.099962954584931
    nreg2bS(31) = -3.2632037778459E-03
    nreg2bS(32) = 2.3320922576723E-04
    nreg2bS(33) = -0.1533480985745
    nreg2bS(34) = 0.029072288239902
    nreg2bS(35) = 3.7534702741167E-04
    nreg2bS(36) = 1.7296691702411E-03
    nreg2bS(37) = -3.8556050844504E-04
    nreg2bS(38) = -3.5017712292608E-05
    nreg2bS(39) = -1.4566393631492E-05
    nreg2bS(40) = 5.6420857267269E-06
    nreg2bS(41) = 4.1286150074605E-08
    nreg2bS(42) = -2.0684671118824E-08
    nreg2bS(43) = 1.6409393674725E-09
End Sub

Sub InitFieldsreg2cS()
    ireg2cS(0) = -2
    ireg2cS(1) = -2
    ireg2cS(2) = -1
    ireg2cS(3) = 0
    ireg2cS(4) = 0
    ireg2cS(5) = 0
    ireg2cS(6) = 0
    ireg2cS(7) = 1
    ireg2cS(8) = 1
    ireg2cS(9) = 1
    ireg2cS(10) = 1
    ireg2cS(11) = 2
    ireg2cS(12) = 2
    ireg2cS(13) = 2
    ireg2cS(14) = 3
    ireg2cS(15) = 3
    ireg2cS(16) = 3
    ireg2cS(17) = 4
    ireg2cS(18) = 4
    ireg2cS(19) = 4
    ireg2cS(20) = 5
    ireg2cS(21) = 5
    ireg2cS(22) = 5
    ireg2cS(23) = 6
    ireg2cS(24) = 6
    ireg2cS(25) = 7
    ireg2cS(26) = 7
    ireg2cS(27) = 7
    ireg2cS(28) = 7
    ireg2cS(29) = 7
    jreg2cS(0) = 0
    jreg2cS(1) = 1
    jreg2cS(2) = 0
    jreg2cS(3) = 0
    jreg2cS(4) = 1
    jreg2cS(5) = 2
    jreg2cS(6) = 3
    jreg2cS(7) = 0
    jreg2cS(8) = 1
    jreg2cS(9) = 3
    jreg2cS(10) = 4
    jreg2cS(11) = 0
    jreg2cS(12) = 1
    jreg2cS(13) = 2
    jreg2cS(14) = 0
    jreg2cS(15) = 1
    jreg2cS(16) = 5
    jreg2cS(17) = 0
    jreg2cS(18) = 1
    jreg2cS(19) = 4
    jreg2cS(20) = 0
    jreg2cS(21) = 1
    jreg2cS(22) = 2
    jreg2cS(23) = 0
    jreg2cS(24) = 1
    jreg2cS(25) = 0
    jreg2cS(26) = 1
    jreg2cS(27) = 3
    jreg2cS(28) = 4
    jreg2cS(29) = 5
    nreg2cS(0) = 909.68501005365
    nreg2cS(1) = 2404.566708842
    nreg2cS(2) = -591.6232638713
    nreg2cS(3) = 541.45404128074
    nreg2cS(4) = -270.98308411192
    nreg2cS(5) = 979.76525097926
    nreg2cS(6) = -469.66772959435
    nreg2cS(7) = 14.399274604723
    nreg2cS(8) = -19.104204230429
    nreg2cS(9) = 5.3299167111971
    nreg2cS(10) = -21.252975375934
    nreg2cS(11) = -0.3114733441376
    nreg2cS(12) = 0.60334840894623
    nreg2cS(13) = -0.042764839702509
    nreg2cS(14) = 5.8185597255259E-03
    nreg2cS(15) = -0.014597008284753
    nreg2cS(16) = 5.6631175631027E-03
    nreg2cS(17) = -7.6155864584577E-05
    nreg2cS(18) = 2.2440342919332E-04
    nreg2cS(19) = -1.2561095013413E-05
    nreg2cS(20) = 6.3323132660934E-07
    nreg2cS(21) = -2.0541989675375E-06
    nreg2cS(22) = 3.6405370390082E-08
    nreg2cS(23) = -2.9759897789215E-09
    nreg2cS(24) = 1.0136618529763E-08
    nreg2cS(25) = 5.9925719692351E-12
    nreg2cS(26) = -2.0677870105164E-11
    nreg2cS(27) = -2.0874278181886E-11
    nreg2cS(28) = 1.0162166825089E-10
    nreg2cS(29) = -1.6429828281347E-10
End Sub

Sub InitFieldsreg3aS()
    ireg3aS(0) = -12
    ireg3aS(1) = -12
    ireg3aS(2) = -10
    ireg3aS(3) = -10
    ireg3aS(4) = -10
    ireg3aS(5) = -10
    ireg3aS(6) = -8
    ireg3aS(7) = -8
    ireg3aS(8) = -8
    ireg3aS(9) = -8
    ireg3aS(10) = -6
    ireg3aS(11) = -6
    ireg3aS(12) = -6
    ireg3aS(13) = -5
    ireg3aS(14) = -5
    ireg3aS(15) = -5
    ireg3aS(16) = -4
    ireg3aS(17) = -4
    ireg3aS(18) = -4
    ireg3aS(19) = -2
    ireg3aS(20) = -2
    ireg3aS(21) = -1
    ireg3aS(22) = -1
    ireg3aS(23) = 0
    ireg3aS(24) = 0
    ireg3aS(25) = 0
    ireg3aS(26) = 1
    ireg3aS(27) = 2
    ireg3aS(28) = 2
    ireg3aS(29) = 3
    ireg3aS(30) = 8
    ireg3aS(31) = 8
    ireg3aS(32) = 10
    jreg3aS(0) = 28
    jreg3aS(1) = 32
    jreg3aS(2) = 4
    jreg3aS(3) = 10
    jreg3aS(4) = 12
    jreg3aS(5) = 14
    jreg3aS(6) = 5
    jreg3aS(7) = 7
    jreg3aS(8) = 8
    jreg3aS(9) = 28
    jreg3aS(10) = 2
    jreg3aS(11) = 6
    jreg3aS(12) = 32
    jreg3aS(13) = 0
    jreg3aS(14) = 14
    jreg3aS(15) = 32
    jreg3aS(16) = 6
    jreg3aS(17) = 10
    jreg3aS(18) = 36
    jreg3aS(19) = 1
    jreg3aS(20) = 4
    jreg3aS(21) = 1
    jreg3aS(22) = 6
    jreg3aS(23) = 0
    jreg3aS(24) = 1
    jreg3aS(25) = 4
    jreg3aS(26) = 0
    jreg3aS(27) = 0
    jreg3aS(28) = 3
    jreg3aS(29) = 2
    jreg3aS(30) = 0
    jreg3aS(31) = 1
    jreg3aS(32) = 2
    nreg3aS(0) = 1500420082.63875
    nreg3aS(1) = -159397258480.424
    nreg3aS(2) = 5.02181140217975E-04
    nreg3aS(3) = -67.2057767855466
    nreg3aS(4) = 1450.58545404456
    nreg3aS(5) = -8238.8953488889
    nreg3aS(6) = -0.154852214233853
    nreg3aS(7) = 11.2305046746695
    nreg3aS(8) = -29.7000213482822
    nreg3aS(9) = 43856513263.5495
    nreg3aS(10) = 1.37837838635464E-03
    nreg3aS(11) = -2.97478527157462
    nreg3aS(12) = 9717779473494.13
    nreg3aS(13) = -5.71527767052398E-05
    nreg3aS(14) = 28830.794977842
    nreg3aS(15) = -74442828926270.3
    nreg3aS(16) = 12.8017324848921
    nreg3aS(17) = -368.275545889071
    nreg3aS(18) = 6.64768904779177E+15
    nreg3aS(19) = 0.044935925195888
    nreg3aS(20) = -4.22897836099655
    nreg3aS(21) = -0.240614376434179
    nreg3aS(22) = -4.74341365254924
    nreg3aS(23) = 0.72409399912611
    nreg3aS(24) = 0.923874349695897
    nreg3aS(25) = 3.99043655281015
    nreg3aS(26) = 3.84066651868009E-02
    nreg3aS(27) = -3.59344365571848E-03
    nreg3aS(28) = -0.735196448821653
    nreg3aS(29) = 0.188367048396131
    nreg3aS(30) = 1.41064266818704E-04
    nreg3aS(31) = -2.57418501496337E-03
    nreg3aS(32) = 1.23220024851555E-03
End Sub

Sub InitFieldsreg3bS()
    ireg3bS(0) = -12
    ireg3bS(1) = -12
    ireg3bS(2) = -12
    ireg3bS(3) = -12
    ireg3bS(4) = -8
    ireg3bS(5) = -8
    ireg3bS(6) = -8
    ireg3bS(7) = -6
    ireg3bS(8) = -6
    ireg3bS(9) = -6
    ireg3bS(10) = -5
    ireg3bS(11) = -5
    ireg3bS(12) = -5
    ireg3bS(13) = -5
    ireg3bS(14) = -5
    ireg3bS(15) = -4
    ireg3bS(16) = -3
    ireg3bS(17) = -3
    ireg3bS(18) = -2
    ireg3bS(19) = 0
    ireg3bS(20) = 2
    ireg3bS(21) = 3
    ireg3bS(22) = 4
    ireg3bS(23) = 5
    ireg3bS(24) = 6
    ireg3bS(25) = 8
    ireg3bS(26) = 12
    ireg3bS(27) = 14
    jreg3bS(0) = 1
    jreg3bS(1) = 3
    jreg3bS(2) = 4
    jreg3bS(3) = 7
    jreg3bS(4) = 0
    jreg3bS(5) = 1
    jreg3bS(6) = 3
    jreg3bS(7) = 0
    jreg3bS(8) = 2
    jreg3bS(9) = 4
    jreg3bS(10) = 0
    jreg3bS(11) = 1
    jreg3bS(12) = 2
    jreg3bS(13) = 4
    jreg3bS(14) = 6
    jreg3bS(15) = 12
    jreg3bS(16) = 1
    jreg3bS(17) = 6
    jreg3bS(18) = 2
    jreg3bS(19) = 0
    jreg3bS(20) = 1
    jreg3bS(21) = 1
    jreg3bS(22) = 0
    jreg3bS(23) = 24
    jreg3bS(24) = 0
    jreg3bS(25) = 3
    jreg3bS(26) = 1
    jreg3bS(27) = 2
    nreg3bS(0) = 0.52711170160166
    nreg3bS(1) = -40.1317830052742
    nreg3bS(2) = 153.020073134484
    nreg3bS(3) = -2247.99398218827
    nreg3bS(4) = -0.193993484669048
    nreg3bS(5) = -1.40467557893768
    nreg3bS(6) = 42.6799878114024
    nreg3bS(7) = 0.752810643416743
    nreg3bS(8) = 22.6657238616417
    nreg3bS(9) = -622.873556909932
    nreg3bS(10) = -0.660823667935396
    nreg3bS(11) = 0.841267087271658
    nreg3bS(12) = -25.3717501764397
    nreg3bS(13) = 485.708963532948
    nreg3bS(14) = 880.531517490555
    nreg3bS(15) = 2650155.92794626
    nreg3bS(16) = -0.359287150025783
    nreg3bS(17) = -656.991567673753
    nreg3bS(18) = 2.41768149185367
    nreg3bS(19) = 0.856873461222588
    nreg3bS(20) = 0.655143675313458
    nreg3bS(21) = -0.213535213206406
    nreg3bS(22) = 5.62974957606348E-03
    nreg3bS(23) = -316955725450471#
    nreg3bS(24) = -6.99997000152457E-04
    nreg3bS(25) = 1.19845803210767E-02
    nreg3bS(26) = 1.93848122022095E-05
    nreg3bS(27) = -2.15095749182309E-05
End Sub

Sub InitFieldsreg2b2c()
    reg2b2c(0) = 905.84278514723
    reg2b2c(1) = -0.67955786399241
    reg2b2c(2) = 1.2809002730136E-04
    reg2b2c(3) = 2652.6571908428
    reg2b2c(4) = 4.5257578905948
End Sub

Sub InitFieldsreg3a3b()
    reg3a3b(0) = 2014.64004206875
    reg3a3b(1) = 3.74696550136983
    reg3a3b(2) = -2.19921901054187E-02
    reg3a3b(3) = 8.7513168600995E-05
End Sub

Private Function gammareg1(tau As Double, pi As Double) As Double
    Call InitFieldsreg1
    gammareg1 = 0
    For i = 0 To 33
        gammareg1 = gammareg1 + nreg1(i) * (7.1 - pi) ^ ireg1(i) * (tau - 1.222) ^ jreg1(i)
    Next i
End Function

Private Function gammapireg1(tau As Double, pi As Double) As Double
    Call InitFieldsreg1
    gammapireg1 = 0#
    For i = 0 To 33
        gammapireg1 = gammapireg1 - nreg1(i) * ireg1(i) * (7.1 - pi) ^ (ireg1(i) - 1) * (tau - 1.222) ^ jreg1(i)
    Next i
End Function

Private Function gammapipireg1(tau As Double, pi As Double) As Double
    Call InitFieldsreg1
    gammapipireg1 = 0
    For i = 0 To 33
        gammapipireg1 = gammapipireg1 + nreg1(i) * ireg1(i) * (ireg1(i) - 1) * (7.1 - pi) ^ (ireg1(i) - 2) * (tau - 1.222) ^ jreg1(i)
    Next i
End Function

Private Function gammataureg1(tau As Double, pi As Double) As Double
    Call InitFieldsreg1
    gammataureg1 = 0
    For i = 0 To 33
        gammataureg1 = gammataureg1 + nreg1(i) * (7.1 - pi) ^ ireg1(i) * jreg1(i) * (tau - 1.222) ^ (jreg1(i) - 1)
    Next i
End Function

Private Function gammatautaureg1(tau As Double, pi As Double) As Double
    Call InitFieldsreg1
    gammatautaureg1 = 0
    For i = 0 To 33
        gammatautaureg1 = gammatautaureg1 + nreg1(i) * (7.1 - pi) ^ ireg1(i) * jreg1(i) * (jreg1(i) - 1) * (tau - 1.222) ^ (jreg1(i) - 2)
    Next i
End Function '

Private Function gammapitaureg1(tau As Double, pi As Double) As Double
    Call InitFieldsreg1
    gammapitaureg1 = 0
    For i = 0 To 33
        gammapitaureg1 = gammapitaureg1 - nreg1(i) * ireg1(i) * (7.1 - pi) ^ (ireg1(i) - 1) * jreg1(i) * (tau - 1.222) ^ (jreg1(i) - 1)
    Next i
End Function

Private Function gamma0reg2(tau As Double, pi As Double) As Double
    Call InitFieldsreg2
    gamma0reg2 = Math.Log(pi)
    For i = 0 To 8
        gamma0reg2 = gamma0reg2 + n0reg2(i) * tau ^ j0reg2(i)
    Next i
End Function

Private Function gamma0pireg2(tau, pi)
    gamma0pireg2 = 1 / pi
End Function

Private Function gamma0pipireg2(tau, pi)
    gamma0pipireg2 = -1 / pi ^ 2
End Function

Private Function gamma0taureg2(tau As Double, pi As Double) As Double
    Call InitFieldsreg2
    gamma0taureg2 = 0
    For i = 0 To 8
        gamma0taureg2 = gamma0taureg2 + n0reg2(i) * j0reg2(i) * tau ^ (j0reg2(i) - 1)
    Next i
End Function

Private Function gamma0tautaureg2(tau As Double, pi As Double) As Double
    Call InitFieldsreg2
    gamma0tautaureg2 = 0
    For i = 0 To 8
        gamma0tautaureg2 = gamma0tautaureg2 + n0reg2(i) * j0reg2(i) * (j0reg2(i) - 1) * tau ^ (j0reg2(i) - 2)
    Next i
End Function

Private Function gamma0pitaureg2(tau, pi)
    gamma0pitaureg2 = 0
End Function

Private Function gammarreg2(tau As Double, pi As Double) As Double
    Call InitFieldsreg2
    gammarreg2 = 0
    For i = 0 To 42
        gammarreg2 = gammarreg2 + nreg2(i) * pi ^ ireg2(i) * (tau - 0.5) ^ jreg2(i)
    Next i
End Function

Private Function gammarpireg2(tau, pi)
    Call InitFieldsreg2
    gammarpireg2 = 0
    For i = 0 To 42
        gammarpireg2 = gammarpireg2 + nreg2(i) * ireg2(i) * pi ^ (ireg2(i) - 1) * (tau - 0.5) ^ jreg2(i)
    Next i
End Function

Private Function gammarpipireg2(tau, pi)
    Call InitFieldsreg2
    gammarpipireg2 = 0
    For i = 0 To 42
        gammarpipireg2 = gammarpipireg2 + nreg2(i) * ireg2(i) * (ireg2(i) - 1) * pi ^ (ireg2(i) - 2) * (tau - 0.5) ^ jreg2(i)
    Next i
End Function

Private Function gammartaureg2(tau As Double, pi As Double) As Double
    Call InitFieldsreg2
    gammartaureg2 = 0
    For i = 0 To 42
        gammartaureg2 = gammartaureg2 + nreg2(i) * pi ^ ireg2(i) * jreg2(i) * (tau - 0.5) ^ (jreg2(i) - 1)
    Next i
End Function

Private Function gammartautaureg2(tau As Double, pi As Double) As Double
    Call InitFieldsreg2
    gammartautaureg2 = 0
    For i = 0 To 42
        gammartautaureg2 = gammartautaureg2 + nreg2(i) * pi ^ ireg2(i) * jreg2(i) * (jreg2(i) - 1) * (tau - 0.5) ^ (jreg2(i) - 2)
    Next i
End Function

Private Function gammarpitaureg2(tau, pi)
    Call InitFieldsreg2
    gammarpitaureg2 = 0
    For i = 0 To 42
        gammarpitaureg2 = gammarpitaureg2 + nreg2(i) * ireg2(i) * pi ^ (ireg2(i) - 1) * jreg2(i) * (tau - 0.5) ^ (jreg2(i) - 1)
    Next i
End Function

Private Function fireg3(tau As Double, delta As Double) As Double
    Call InitFieldsreg3
    fireg3 = nreg3(0) * Math.Log(delta)
    For i = 1 To 39
        fireg3 = fireg3 + nreg3(i) * delta ^ ireg3(i) * tau ^ jreg3(i)
    Next i
End Function

Private Function fideltareg3(tau As Double, delta As Double) As Double
    Call InitFieldsreg3
    fideltareg3 = nreg3(0) / delta
    For i = 1 To 39
        fideltareg3 = fideltareg3 + nreg3(i) * ireg3(i) * delta ^ (ireg3(i) - 1) * tau ^ jreg3(i)
    Next i
End Function

Private Function fideltadeltareg3(tau As Double, delta As Double) As Double
    Call InitFieldsreg3
    fideltadeltareg3 = -nreg3(0) / delta ^ 2
    For i = 1 To 39
        fideltadeltareg3 = fideltadeltareg3 + nreg3(i) * ireg3(i) * (ireg3(i) - 1) * delta ^ (ireg3(i) - 2) * tau ^ jreg3(i)
    Next i
End Function

Private Function fitaureg3(tau As Double, delta As Double) As Double
    Call InitFieldsreg3
    fitaureg3 = 0
    For i = 1 To 39
        fitaureg3 = fitaureg3 + nreg3(i) * delta ^ ireg3(i) * jreg3(i) * tau ^ (jreg3(i) - 1)
    Next i
End Function

Private Function fitautaureg3(tau As Double, delta As Double) As Double
    Call InitFieldsreg3
    fitautaureg3 = 0
    For i = 1 To 39
        fitautaureg3 = fitautaureg3 + nreg3(i) * delta ^ ireg3(i) * jreg3(i) * (jreg3(i) - 1) * tau ^ (jreg3(i) - 2)
    Next i
End Function

Private Function fideltataureg3(tau As Double, delta As Double) As Double
    Call InitFieldsreg3
    fideltataureg3 = 0
    For i = 1 To 39
        fideltataureg3 = fideltataureg3 + nreg3(i) * ireg3(i) * delta ^ (ireg3(i) - 1) * jreg3(i) * tau ^ (jreg3(i) - 1)
    Next i
End Function

Private Function psivisc(tau As Double, delta As Double) As Double
    Dim psi0 As Double, psi1 As Double
    Call InitFieldsvisc
    psi0 = 0
    psi1 = 0
    For i = 0 To 3
        psi0 = psi0 + n0visc(i) * tau ^ i
    Next i
    psi0 = 1 / (tau ^ 0.5 * psi0)
    For i = 0 To 18
        psi1 = psi1 + nvisc(i) * (delta - 1#) ^ ivisc(i) * (tau - 1#) ^ jvisc(i)
    Next i
    psi1 = Math.Exp(delta * psi1)
    psivisc = psi0 * psi1
End Function

'
'######################################################################################################################################
'

Private Function T2P(T As Double) As Double
    If T < Tmin Or T > Tcrit Then
        T2P = -1#
        Exit Function
    End If
    Call InitFieldsreg4
    Dim theta As Double, A As Double, B As Double, C As Double
    theta = T + nreg4(8) / (T - nreg4(9))
    A = theta * theta + nreg4(0) * theta + nreg4(1)
    B = nreg4(2) * theta * theta + nreg4(3) * theta + nreg4(4)
    C = nreg4(5) * theta * theta + nreg4(6) * theta + nreg4(7)
    T2P = (2 * C / (-B + (B * B - 4 * A * C) ^ 0.5)) ^ 4
End Function

Private Function P2T(P As Double) As Double
    If P < Pmin Or P > Pcrit Then
        P2T = -1#
        Exit Function
    End If
    Call InitFieldsreg4
    Dim beta As Double, D As Double, E As Double, F As Double, G As Double
    beta = P ^ 0.25
    E = beta * beta + nreg4(2) * beta + nreg4(5)
    F = nreg4(0) * beta * beta + nreg4(3) * beta + nreg4(6)
    G = nreg4(1) * beta * beta + nreg4(4) * beta + nreg4(7)
    D = 2 * G / (-F - (F * F - 4 * E * G) ^ 0.5)
    P2T = 0.5 * (nreg4(9) + D - ((nreg4(9) + D) ^ 2 - 4 * (nreg4(8) + nreg4(9) * D)) ^ 0.5)
End Function

Private Function Region23_T(T As Double) As Double
    Call InitFieldsreg23
    Region23_T = nreg23(0) + nreg23(1) * T + nreg23(2) * T * T
End Function

Private Function Region23_P(P As Double) As Double
    Call InitFieldsreg23
    Region23_P = nreg23(3) + ((P - nreg23(4)) / nreg23(2)) ^ 0.5
End Function

Private Function Region_PT(P As Double, T As Double) As Integer
    If P < Pmin Or P > Pmax Or T < Tmin Or T > Tmax Then
        Region_PT = -1
    ElseIf T > T23min Then
        If P < 16.5292 Then
            Region_PT = 2
        ElseIf P > Region23_T(T) Then
            Region_PT = 3
        Else
            Region_PT = 2
        End If
    Else
        If P > T2P(T) Then
            Region_PT = 1
        ElseIf P < T2P(T) Then
            Region_PT = 2
        Else
            Region_PT = 4
        End If
    End If
End Function

'
'######################################################################################################################################
'

Private Function PT2Vreg1(P As Double, T As Double) As Double
    Dim tau As Double, pi As Double
    tau = 1386# / T
    pi = P / 16.53
    PT2Vreg1 = Rgas * T * pi * gammapireg1(tau, pi) / (P * 1000#)
End Function

Private Function PT2Vreg2(P As Double, T As Double) As Double
    Dim tau As Double, pi As Double
    tau = 540# / T
    pi = P
    PT2Vreg2 = Rgas * T * pi * (gamma0pireg2(tau, pi) + gammarpireg2(tau, pi)) / (P * 1000#)
End Function

Private Function PT2Dreg3(P As Double, T As Double) As Double
    Dim DensOld As Double, tau As Double, delta As Double, derivprho As Double, DensNew As Double, diffdens As Double
    If T < Tcrit And P < T2P(T) Then
        DensOld = 100#
    Else
        DensOld = 600#
    End If
    tau = Tcrit / T
    For j = 1 To 1000
        delta = DensOld / Rhocrit
        derivprho = Rgas * 1000# * T / Rhocrit * (2 * DensOld * fideltareg3(tau, delta) + DensOld ^ 2 / Rhocrit * fideltadeltareg3(tau, delta))
        DensNew = DensOld + (P * 1000000# - Rgas * 1000# * T * DensOld ^ 2 / Rhocrit * fideltareg3(tau, delta)) / derivprho
        diffdens = Math.Abs(DensNew - DensOld)
        If diffdens < 0.000005 Then
            PT2Dreg3 = DensNew
            Exit Function
        End If
        DensOld = DensNew
    Next j
    PT2Dreg3 = -1#
End Function

Private Function PT2D(P As Double, T As Double) As Double
    Select Case Region_PT(P, T)
        Case 1
            PT2D = 1 / PT2Vreg1(P, T)
        Case 2
            PT2D = 1 / PT2Vreg2(P, T)
        Case 3
            PT2D = PT2Dreg3(P, T)
        Case Else
            PT2D = -1#
    End Select
End Function

'
'######################################################################################################################################
'

Private Function PT2Ereg1(P As Double, T As Double) As Double
    Dim tau As Double, pi As Double
    tau = 1386# / T
    pi = P / 16.53
    PT2Ereg1 = Rgas * T * (tau * gammataureg1(tau, pi) - pi * gammapireg1(tau, pi))
End Function

Private Function PT2Ereg2(P As Double, T As Double) As Double
    Dim tau As Double, pi As Double
    tau = 540# / T
    pi = P
    PT2Ereg2 = Rgas * T * (tau * (gamma0taureg2(tau, pi) + gammartaureg2(tau, pi)) - pi * (gamma0pireg2(tau, pi) + gammarpireg2(tau, pi)))
End Function

Private Function TD2Ereg3(T As Double, D As Double) As Double
    Dim tau As Double, delta As Double
    tau = Tcrit / T
    delta = D / Rhocrit
    TD2Ereg3 = Rgas * T * tau * fitaureg3(tau, delta)
End Function

Private Function PT2E(P As Double, T As Double) As Double
    Select Case Region_PT(P, T)
        Case 1
            PT2E = PT2Ereg1(P, T)
        Case 2
            PT2E = PT2Ereg2(P, T)
        Case 3
            PT2E = TD2Ereg3(T, PT2Dreg3(P, T))
        Case Else
            PT2E = -1#
    End Select
End Function

'
'######################################################################################################################################
'

Private Function PT2Hreg1(P As Double, T As Double) As Double
    Dim tau As Double, pi As Double
    tau = 1386# / T
    pi = P / 16.53
    PT2Hreg1 = Rgas * T * tau * gammataureg1(tau, pi)
End Function

Private Function PT2Hreg2(P As Double, T As Double) As Double
    Dim tau As Double, pi As Double
    tau = 540# / T
    pi = P
    PT2Hreg2 = Rgas * T * tau * (gamma0taureg2(tau, pi) + gammartaureg2(tau, pi))
End Function

Private Function TD2Hreg3(T As Double, D As Double) As Double
    Dim tau As Double, delta As Double
    tau = Tcrit / T
    delta = D / Rhocrit
    TD2Hreg3 = Rgas * T * (tau * fitaureg3(tau, delta) + delta * fideltareg3(tau, delta))
End Function

Private Function PT2H(P As Double, T As Double) As Double
    Select Case Region_PT(P, T)
        Case 1
            PT2H = PT2Hreg1(P, T)
        Case 2
            PT2H = PT2Hreg2(P, T)
        Case 3
            PT2H = TD2Hreg3(T, PT2Dreg3(P, T))
        Case Else
            PT2H = -1#
    End Select
End Function

'
'######################################################################################################################################
'

Private Function PT2Sreg1(P As Double, T As Double) As Double
    Dim tau As Double, pi As Double
    tau = 1386# / T
    pi = P / 16.53
    PT2Sreg1 = Rgas * (tau * gammataureg1(tau, pi) - gammareg1(tau, pi))
End Function

Private Function PT2Sreg2(P As Double, T As Double) As Double
    Dim tau As Double, pi As Double
    tau = 540# / T
    pi = P
    PT2Sreg2 = Rgas * (tau * (gamma0taureg2(tau, pi) + gammartaureg2(tau, pi)) - (gamma0reg2(tau, pi) + gammarreg2(tau, pi)))
End Function

Private Function TD2Sreg3(T As Double, D As Double) As Double
    Dim tau As Double, delta As Double
    tau = Tcrit / T
    delta = D / Rhocrit
    TD2Sreg3 = Rgas * (tau * fitaureg3(tau, delta) - fireg3(tau, delta))
End Function

Private Function PT2S(P As Double, T As Double) As Double
    Select Case Region_PT(P, T)
        Case 1
            PT2S = PT2Sreg1(P, T)
        Case 2
            PT2S = PT2Sreg2(P, T)
        Case 3
            PT2S = TD2Sreg3(T, PT2Dreg3(P, T))
        Case Else
            PT2S = -1#
    End Select
End Function

'
'######################################################################################################################################
'

Private Function PT2CPreg1(P As Double, T As Double) As Double
    Dim tau As Double, pi As Double
    tau = 1386# / T
    pi = P / 16.53
    PT2CPreg1 = -1 * Rgas * tau ^ 2 * gammatautaureg1(tau, pi)
End Function

Private Function PT2CPreg2(P As Double, T As Double) As Double
    Dim tau As Double, pi As Double
    tau = 540# / T
    pi = P
    PT2CPreg2 = -1 * Rgas * tau ^ 2 * (gamma0tautaureg2(tau, pi) + gammartautaureg2(tau, pi))
End Function

Private Function TD2CPreg3(T As Double, D As Double) As Double
    Dim tau As Double, delta As Double
    tau = Tcrit / T
    delta = D / Rhocrit
    TD2CPreg3 = Rgas * (-tau ^ 2 * fitautaureg3(tau, delta) + (delta * fideltareg3(tau, delta) - delta * tau * fideltataureg3(tau, delta)) ^ 2 / (2 * delta * fideltareg3(tau, delta) + delta ^ 2 * fideltadeltareg3(tau, delta)))
End Function

Private Function PT2CP(P As Double, T As Double) As Double
    Select Case Region_PT(P, T)
        Case 1
            PT2CP = PT2CPreg1(P, T)
        Case 2
            PT2CP = PT2CPreg2(P, T)
        Case 3
            PT2CP = TD2CPreg3(T, PT2Dreg3(P, T))
        Case Else
            PT2CP = -1#
    End Select
End Function

'
'######################################################################################################################################
'

Private Function PT2CVreg1(P As Double, T As Double) As Double
    Dim tau As Double, pi As Double
    tau = 1386# / T
    pi = P / 16.53
    PT2CVreg1 = Rgas * (-tau ^ 2 * gammatautaureg1(tau, pi) + (gammapireg1(tau, pi) - tau * gammapitaureg1(tau, pi)) ^ 2 / gammapipireg1(tau, pi))
End Function

Private Function PT2CVreg2(P As Double, T As Double) As Double
    Dim tau As Double, pi As Double
    tau = 540# / T
    pi = P
    PT2CVreg2 = Rgas * (-tau ^ 2 * (gamma0tautaureg2(tau, pi) + gammartautaureg2(tau, pi)) - (1 + pi * gammarpireg2(tau, pi) - tau * pi * gammarpitaureg2(tau, pi)) ^ 2 / (1 - pi ^ 2 * gammarpipireg2(tau, pi)))
End Function

Private Function TD2CVreg3(T As Double, D As Double) As Double
    Dim tau As Double, delta As Double
    tau = Tcrit / T
    delta = D / Rhocrit
    TD2CVreg3 = Rgas * (-tau ^ 2 * fitautaureg3(tau, delta))
End Function

Private Function PT2CV(P As Double, T As Double) As Double
    Select Case Region_PT(P, T)
        Case 1
            PT2CV = PT2CVreg1(P, T)
        Case 2
            PT2CV = PT2CVreg2(P, T)
        Case 3
            PT2CV = TD2CVreg3(T, PT2Dreg3(P, T))
        Case Else
            PT2CV = -1#
    End Select
End Function

'
'######################################################################################################################################
'

Private Function PT2ETA(P As Double, T As Double) As Double
    If T >= Tmin And T <= Tmax And P > Pmin And P <= Pmax Then
        PT2ETA = 0.000055071 * psivisc(647.226 / T, PT2D(P, T) / 317.763)
    Else
        PT2ETA = -1#
    End If
End Function

Private Function lambthcon(P As Double, T As Double, tau As Double, delta As Double) As Double
    Dim lamb0 As Double, lamb1 As Double,lamb2 As Double, taus As Double, pis As Double, dpidtau As Double, ddeltadpi As Double, deltas As Double
    Call InitFieldsthcon
    lamb0 = 0
    lamb1 = 0
    For i = 0 To 3
        lamb0 = lamb0 + n0thcon(i) * tau ^ i
    Next i
    lamb0 = 1 / (tau ^ 0.5 * lamb0)
    For i = 0 To 4
        For j = 0 To 5
            lamb1 = lamb1 + nthcon(i, j) * (tau - 1#) ^ i * (delta - 1#) ^ j
        Next j
    Next i
    lamb1 = Math.Exp(delta * lamb1)
    Select Case Region_PT(P, T)
        Case 1
            taus = 1386# / T
            pis = P / 16.53
            dpidtau = (647.226 * 165.3 * (gammapitaureg1(taus, pis) * 1386# - gammapireg1(taus, pis) * T)) / (221.15 * T ^ 2 * gammapipireg1(taus, pis))
            ddeltadpi = -(22115000# * gammapipireg1(taus, pis)) / (317.763 * Rgas * 1000 * T * gammapireg1(taus, pis) ^ 2)
        Case 2
            taus = 540# / T
            pis = P
            dpidtau = (647.226 * 10# * ((gamma0pitaureg2(taus, pis) + gammarpitaureg2(taus, pis)) * 540# - (gamma0pireg2(taus, pis) + gammarpireg2(taus, pis)) * T)) / (221.15 * T ^ 2 * (gamma0pipireg2(taus, pis) + gammarpipireg2(taus, pis)))
            ddeltadpi = -(22115000# * (gamma0pipireg2(taus, pis) + gammarpipireg2(taus, pis))) / (317.763 * Rgas * 1000 * T * (gamma0pireg2(taus, pis) + gammarpireg2(taus, pis)) ^ 2)
        Case 3
            taus = 647.096 / T
            deltas = delta * 317.763 / Rhocrit
            dpidtau = (647.226 * Rgas * 1000 * (delta * 317.763) ^ 2 * (fideltareg3(taus, deltas) - (647.096 / T) * fideltataureg3(taus, deltas))) / (22115000# * Rhocrit)
            ddeltadpi = (22115000# * Rhocrit) / (317.763 * delta * 317.763 * Rgas * 1000 * T * (2 * fideltareg3(taus, deltas) + (delta * 317.763 / Rhocrit) * fideltadeltareg3(taus, deltas)))
        Case Else
            dpidtau = 0
            ddeltadpi = 0
    End Select
    lamb2 = 0.0013848 / psivisc(tau, delta) * (tau * delta) ^ (-2) * dpidtau ^ 2 * (delta * ddeltadpi) ^ 0.4678 * delta ^ 0.5 * Math.Exp(-18.66 * (1 / tau - 1) ^ 2 - (delta - 1) ^ 4)
    lambthcon = lamb0 * lamb1 + lamb2
End Function

Private Function PT2RAMD(P As Double, T As Double) As Double
    If T >= Tmin And T <= Tmax And P > Pmin And P <= Pmax Then
        PT2RAMD = 0.4945 * lambthcon(P, T, 647.226 / T, PT2D(P, T) / 317.763)
    Else
        PT2RAMD = -1#
    End If
End Function

'
'######################################################################################################################################
'

Private Function T2D_liq(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2D_liq = 1 / PT2Vreg1(T2P(T), T)
    ElseIf T > T23min And T <= Tcrit Then
        T2D_liq = PT2Dreg3(T2P(T), T)
    Else
        T2D_liq = -1#
    End If
End Function

Private Function T2D_vap(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2D_vap = 1 / PT2Vreg2(T2P(T), T)
    ElseIf T > T23min And T <= Tcrit Then
        T2D_vap = PT2Dreg3(T2P(T) - 0.00001, T)
    Else
        T2D_vap = -1#
    End If
End Function

Private Function P2D_liq(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2D_liq = 1 / PT2Vreg1(P, T)
    ElseIf T > T23min And T <= Tcrit Then
        P2D_liq = PT2Dreg3(P + 0.00001, T)
    Else
        P2D_liq = -1#
    End If
End Function

Private Function P2D_vap(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2D_vap = 1 / PT2Vreg2(T2P(T), T)
    ElseIf T > T23min And T <= Tcrit Then
        P2D_vap = PT2Dreg3(T2P(T) - 0.00001, T)
    Else
        P2D_vap = -1#
    End If
End Function

Private Function TX2V(T As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        TX2V = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = 1 / T2D_liq(T)
        R2 = 1 / T2D_vap(T)
        TX2V = R1 + (R2 - R1) * X
    End If
End Function

Private Function PX2V(P As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        PX2V = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = 1 / P2D_liq(P)
        R2 = 1 / P2D_vap(P)
        PX2V = R1 + (R2 - R1) * X
    End If
End Function

'
'######################################################################################################################################
'
Private Function T2E_liq(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2E_liq = PT2Ereg1(T2P(T), T)
    ElseIf T > T23min And T <= Tcrit Then
        T2E_liq = TD2Ereg3(T, PT2Dreg3(T2P(T), T))
    Else
        T2E_liq = -1#
    End If
End Function

Private Function T2E_vap(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2E_vap = PT2Ereg2(T2P(T), T)
    ElseIf T > T23min And T <= Tcrit Then
        T2E_vap = TD2Ereg3(T, PT2Dreg3(T2P(T) - 0.00001, T))
    Else
        T2E_vap = -1#
    End If
End Function

Private Function P2E_liq(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2E_liq = PT2Ereg1(P, T)
    ElseIf T > T23min And T <= Tcrit Then
        P2E_liq = TD2Ereg3(T, PT2Dreg3(P + 0.00001, T))
    Else
        P2E_liq = -1#
    End If
End Function

Private Function P2E_vap(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2E_vap = PT2Ereg2(P, T)
    ElseIf T > T23min And T <= Tcrit Then
        P2E_vap = TD2Ereg3(T, PT2Dreg3(P - 0.00001, T))
    Else
        P2E_vap = -1#
    End If
End Function

Private Function TX2E(T As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        TX2E = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = T2E_liq(T)
        R2 = T2E_vap(T)
        TX2E = R1 + (R2 - R1) * X
    End If
End Function

Private Function PX2E(P As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        PX2E = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = P2E_liq(P)
        R2 = P2E_vap(P)
        PX2E = R1 + (R2 - R1) * X
    End If
End Function
'
'######################################################################################################################################
'
Private Function T2H_liq(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2H_liq = PT2Hreg1(T2P(T), T)
    ElseIf T > T23min And T <= Tcrit Then
        T2H_liq = TD2Hreg3(T, PT2Dreg3(T2P(T), T))
    Else
        T2H_liq = -1#
    End If
End Function

Private Function T2H_vap(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2H_vap = PT2Hreg2(T2P(T), T)
    ElseIf T > T23min And T <= Tcrit Then
        T2H_vap = TD2Hreg3(T, PT2Dreg3(T2P(T) - 0.00001, T))
    Else
        T2H_vap = -1#
    End If
End Function

Private Function P2H_liq(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2H_liq = PT2Hreg1(P, T)
    ElseIf T > T23min And T <= Tcrit Then
        P2H_liq = TD2Hreg3(T, PT2Dreg3(P + 0.00001, T))
    Else
        P2H_liq = -1#
    End If
End Function

Private Function P2H_vap(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2H_vap = PT2Hreg2(P, T)
    ElseIf T > T23min And T <= Tcrit Then
        P2H_vap = TD2Hreg3(T, PT2Dreg3(P - 0.00001, T))
    Else
        P2H_vap = -1#
    End If
End Function

Private Function TX2H(T As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        TX2H = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = T2H_liq(T)
        R2 = T2H_vap(T)
        TX2H = R1 + (R2 - R1) * X
    End If
End Function

Private Function PX2H(P As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        PX2H = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = P2H_liq(P)
        R2 = P2H_vap(P)
        PX2H = R1 + (R2 - R1) * X
    End If
End Function
'
'######################################################################################################################################
'
Private Function T2S_liq(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2S_liq = PT2Sreg1(T2P(T), T)
    ElseIf T > T23min And T <= Tcrit Then
        T2S_liq = TD2Sreg3(T, PT2Dreg3(T2P(T), T))
    Else
        T2S_liq = -1#
    End If
End Function

Private Function T2S_vap(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2S_vap = PT2Sreg2(T2P(T), T)
    ElseIf T > T23min And T <= Tcrit Then
        T2S_vap = TD2Sreg3(T, PT2Dreg3(T2P(T) - 0.00001, T))
    Else
        T2S_vap = -1#
    End If
End Function

Private Function P2S_liq(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2S_liq = PT2Sreg1(P, T)
    ElseIf T > T23min And T <= Tcrit Then
        P2S_liq = TD2Sreg3(T, PT2Dreg3(P + 0.00001, T))
    Else
        P2S_liq = -1#
    End If
End Function

Private Function P2S_vap(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2S_vap = PT2Sreg2(P, T)
    ElseIf T > T23min And T <= Tcrit Then
        P2S_vap = TD2Sreg3(T, PT2Dreg3(P - 0.00001, T))
    Else
        P2S_vap = -1#
    End If
End Function

Private Function TX2S(T As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        TX2S = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = T2S_liq(T)
        R2 = T2S_vap(T)
        TX2S = R1 + (R2 - R1) * X
    End If
End Function

Private Function PX2S(P As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        PX2S = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = P2S_liq(P)
        R2 = P2S_vap(P)
        PX2S = R1 + (R2 - R1) * X
    End If
End Function
'
'######################################################################################################################################
'
Private Function T2CP_liq(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2CP_liq = PT2CPreg1(T2P(T), T)
    ElseIf T > T23min And T <= Tcrit Then
        T2CP_liq = TD2CPreg3(T, PT2Dreg3(T2P(T), T))
    Else
        T2CP_liq = -1#
    End If
End Function

Private Function T2CP_vap(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2CP_vap = PT2CPreg2(T2P(T), T)
    ElseIf T > T23min And T <= Tcrit Then
        T2CP_vap = TD2CPreg3(T, PT2Dreg3(T2P(T) - 0.00001, T))
    Else
        T2CP_vap = -1#
    End If
End Function

Private Function P2CP_liq(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2CP_liq = PT2CPreg1(P, T)
    ElseIf T > T23min And T <= Tcrit Then
        P2CP_liq = TD2CPreg3(T, PT2Dreg3(P + 0.00001, T))
    Else
        P2CP_liq = -1#
    End If
End Function

Private Function P2CP_vap(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2CP_vap = PT2CPreg2(P, T)
    ElseIf T > T23min And T <= Tcrit Then
        P2CP_vap = TD2CPreg3(T, PT2Dreg3(P - 0.00001, T))
    Else
        P2CP_vap = -1#
    End If
End Function

Private Function TX2CP(T As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        TX2CP = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = T2CP_liq(T)
        R2 = T2CP_vap(T)
        TX2CP = R1 + (R2 - R1) * X
    End If
End Function

Private Function PX2CP(P As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        PX2CP = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = P2CP_liq(P)
        R2 = P2CP_vap(P)
        PX2CP = R1 + (R2 - R1) * X
    End If
End Function
'
'######################################################################################################################################
'
Private Function T2CV_liq(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2CV_liq = PT2CVreg1(T2P(T), T)
    ElseIf T > T23min And T <= Tcrit Then
        T2CV_liq = TD2CVreg3(T, PT2Dreg3(T2P(T), T))
    Else
        T2CV_liq = -1#
    End If
End Function

Private Function T2CV_vap(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2CV_vap = PT2CVreg2(T2P(T), T)
    ElseIf T > T23min And T <= Tcrit Then
        T2CV_vap = TD2CVreg3(T, PT2Dreg3(T2P(T) - 0.00001, T))
    Else
        T2CV_vap = -1#
    End If
End Function

Private Function P2CV_liq(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2CV_liq = PT2CVreg1(P, T)
    ElseIf T > T23min And T <= Tcrit Then
        P2CV_liq = TD2CVreg3(T, PT2Dreg3(P + 0.00001, T))
    Else
        P2CV_liq = -1#
    End If
End Function

Private Function P2CV_vap(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2CV_vap = PT2CVreg2(P, T)
    ElseIf T > T23min And T <= Tcrit Then
        P2CV_vap = TD2CVreg3(T, PT2Dreg3(P - 0.00001, T))
    Else
        P2CV_vap = -1#
    End If
End Function

Private Function TX2CV(T As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        TX2CV = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = T2CV_liq(T)
        R2 = T2CV_vap(T)
        TX2CV = R1 + (R2 - R1) * X
    End If
End Function

Private Function PX2CV(P As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        PX2CV = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = P2CV_liq(P)
        R2 = P2CV_vap(P)
        PX2CV = R1 + (R2 - R1) * X
    End If
End Function
'
'######################################################################################################################################
'
Private Function T2ETA_liq(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2ETA_liq = 0.000055071 * psivisc(647.226 / T, 1 / PT2Vreg1(T2P(T), T) / 317.763)
    ElseIf T > T23min And T <= Tcrit Then
        T2ETA_liq = 0.000055071 * psivisc(647.226 / T, PT2Dreg3(T2P(T), T) / 317.763)
    Else
        T2ETA_liq = -1#
    End If
End Function

Private Function T2ETA_vap(T As Double) As Double
    If T >= Tmin And T <= T23min Then
        T2ETA_vap = 0.000055071 * psivisc(647.226 / T, 1 / PT2Vreg2(T2P(T), T) / 317.763)
    ElseIf T > T23min And T <= Tcrit Then
        T2ETA_vap = 0.000055071 * psivisc(647.226 / T, PT2Dreg3(T2P(T) - 0.00001, T) / 317.763)
    Else
        T2ETA_vap = -1#
    End If
End Function

Private Function P2ETA_liq(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2ETA_liq = 0.000055071 * psivisc(647.226 / T, 1 / PT2Vreg1(P, T) / 317.763)
    ElseIf T > T23min And T <= Tcrit Then
        P2ETA_liq = 0.000055071 * psivisc(647.226 / T, PT2Dreg3(P + 0.00001, T) / 317.763)
    Else
        P2ETA_liq = -1#
    End If
End Function

Private Function P2ETA_vap(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2ETA_vap = 0.000055071 * psivisc(647.226 / T, 1 / PT2Vreg2(P, T) / 317.763)
    ElseIf T > T23min And T <= Tcrit Then
        P2ETA_vap = 0.000055071 * psivisc(647.226 / T, PT2Dreg3(P - 0.00001, T) / 317.763)
    Else
        P2ETA_vap = -1#
    End If
End Function

Private Function TX2ETA(T As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        TX2ETA = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = T2ETA_liq(T)
        R2 = T2ETA_vap(T)
        TX2ETA = R1 + (R2 - R1) * X
    End If
End Function

Private Function PX2ETA(P As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        PX2ETA = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = P2ETA_liq(P)
        R2 = P2ETA_vap(P)
        PX2ETA = R1 + (R2 - R1) * X
    End If
End Function
'
'######################################################################################################################################
'
Private Function T2RAMD_liq(T As Double) As Double
    Dim P As Double
    P = T2P(T)
    If T >= Tmin And T <= T23min Then
        T2RAMD_liq = 0.4945 * lambthcon(P, T, 647.226 / T, 1 / PT2Vreg1(P, T) / 317.763)
    ElseIf T > T23min And T <= Tcrit Then
        T2RAMD_liq = 0.4945 * lambthcon(P, T, 647.226 / T, PT2Dreg3(P, T) / 317.763)
    Else
        T2RAMD_liq = -1#
    End If
End Function

Private Function T2RAMD_vap(T As Double) As Double
    Dim P As Double
    P = T2P(T)
    If T >= Tmin And T <= T23min Then
        T2RAMD_vap = 0.4945 * lambthcon(P - 0.0001 * P, T, 647.226 / T, 1 / PT2Vreg2(P, T) / 317.763)
    ElseIf T > T23min And T <= Tcrit Then
        T2RAMD_vap = 0.4945 * lambthcon(P - 0.00001, T, 647.226 / T, PT2Dreg3(P - 0.00001, T) / 317.763)
    Else
        T2RAMD_vap = -1#
    End If
End Function

Private Function P2RAMD_liq(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2RAMD_liq = 0.4945 * lambthcon(P, T, 647.226 / T, 1 / PT2Vreg1(P, T) / 317.763)
    ElseIf T > T23min And T <= Tcrit Then
        P2RAMD_liq = 0.4945 * lambthcon(P + 0.00001, T, 647.226 / T, PT2Dreg3(P + 0.00001, T) / 317.763)
    Else
        P2RAMD_liq = -1#
    End If
End Function

Private Function P2RAMD_vap(P As Double) As Double
    Dim T As Double
    T = P2T(P)
    If T >= Tmin And T <= T23min Then
        P2RAMD_vap = 0.4945 * lambthcon(P - 0.0001 * P, T, 647.226 / T, 1 / PT2Vreg2(P, T) / 317.763)
    ElseIf T > T23min And T <= Tcrit Then
        P2RAMD_vap = 0.4945 * lambthcon(P - 0.00001, T, 647.226 / T, PT2Dreg3(P - 0.00001, T) / 317.763)
    Else
        P2RAMD_vap = -1#
    End If
End Function

Private Function TX2RAMD(T As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        TX2RAMD = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = T2RAMD_liq(T)
        R2 = T2RAMD_vap(T)
        TX2RAMD = R1 + (R2 - R1) * X
    End If
End Function

Private Function PX2RAMD(P As Double, X As Double) As Double
    If X < 0 Or X > 1 Then
        PX2RAMD = -1#
    Else
        Dim R1 As Double, R2 As Double
        R1 = P2RAMD_liq(P)
        R2 = P2RAMD_vap(P)
        PX2RAMD = R1 + (R2 - R1) * X
    End If
End Function
'
'######################################################################################################################################
'
Private Function Region_PH(P As Double, H As Double) As Integer
    If P < Pmin Or P > Pmax Then
        Region_PH = -1
        Exit Function
    ElseIf H > PT2H(P, Tmax) Or H < PT2H(P, Tmin) Then
        Region_PH = -1
        Exit Function
    End If
    
    Dim Hliq, Hvap As Double
    Hliq = P2H_liq(P)
    Hvap = P2H_vap(P)
    If P <= Pcrit Then
        If H >= Hliq And H <= Hvap Then
            Region_PH = 4
            Exit Function
        End If
    End If
    
    If P <= P23min Then
        If H <= Hliq Then
            Region_PH = 1
            Exit Function
        ElseIf H >= Hvap Then
            Region_PH = 2
            Exit Function
        Else
            Region_PH = 4
            Exit Function
        End If
    ElseIf H <= PT2H(P, T23min) Then
        Region_PH = 1
        Exit Function
    ElseIf H >= PT2H(P, Region23_P(P)) Then
        Region_PH = 2
        Exit Function
    Else
        Region_PH = 3
    End If
End Function

Private Function PH2T(P As Double, H As Double) As Double
    Dim Result, pi, eta As Double
    Result = 0
    Select Case Region_PH(P, H)
        Case 1
            Call InitFieldsreg1H
            eta = H / 2500
            For i = 0 To 19
                Result = Result + nreg1H(i) * P ^ ireg1H(i) * (eta + 1) ^ jreg1H(i)
            Next
            PH2T = Result
        Case 2
            If P <= 4 Then
                Call InitFieldsreg2aH
                eta = H / 2000
                For i = 0 To 33
                    Result = Result + nreg2aH(i) * P ^ ireg2aH(i) * (eta - 2.1) ^ jreg2aH(i)
                Next
                PH2T = Result
                Exit Function
            End If
            Call InitFieldsreg2b2c
            If H >= reg2b2c(3) + ((P - reg2b2c(4)) / reg2b2c(2)) ^ 0.5 Then
                Call InitFieldsreg2bH
                eta = H / 2000
                For i = 0 To 37
                    Result = Result + nreg2bH(i) * (P - 2) ^ ireg2bH(i) * (eta - 2.6) ^ jreg2bH(i)
                Next
                PH2T = Result
            Else
                Call InitFieldsreg2cH
                eta = H / 2000
                For i = 0 To 22
                    Result = Result + nreg2cH(i) * (P + 25) ^ ireg2cH(i) * (eta - 1.8) ^ jreg2cH(i)
                Next
                PH2T = Result
            End If
        Case 3
            Call InitFieldsreg3a3b
            If H <= reg3a3b(0) + reg3a3b(1) * P + reg3a3b(2) * P * P + reg3a3b(3) * P * P * P Then
                Call InitFieldsreg3aH
                pi = P / 100
                eta = H / 2300
                For i = 0 To 30
                    Result = Result + nreg3aH(i) * (pi + 0.24) ^ ireg3aH(i) * (eta - 0.615) ^ jreg3aH(i)
                Next
                PH2T = Result * 760
            Else
                Call InitFieldsreg3bH
                pi = P / 100
                eta = H / 2800
                For i = 0 To 32
                    Result = Result + nreg3bH(i) * (pi + 0.298) ^ ireg3bH(i) * (eta - 0.72) ^ jreg3bH(i)
                Next
                PH2T = Result * 860
            End If
        Case 4
            PH2T = P2T(P)
            Exit Function
        Case Else
            PH2T = -1
    End Select
End Function

Private Function Region_PS(P As Double, S As Double) As Integer
    If P < Pmin Or P > Pmax Then
        Region_PS = -1
        Exit Function
    ElseIf S > PT2S(P, Tmax) Or S < PT2S(P, Tmin) Then
        Region_PS = -1
        Exit Function
    End If
    
    Dim Sliq, Svap As Double
    Sliq = P2S_liq(P)
    Svap = P2S_vap(P)
    If P <= Pcrit Then
        If S >= Sliq And S <= Svap Then
            Region_PS = 4
            Exit Function
        End If
    End If
    
    If P <= P23min Then
        If S <= Sliq Then
            Region_PS = 1
            Exit Function
        ElseIf S >= Svap Then
            Region_PS = 2
            Exit Function
        Else
            Region_PS = 4
            Exit Function
        End If
    ElseIf S <= PT2S(P, T23min) Then
        Region_PS = 1
        Exit Function
    ElseIf S >= PT2S(P, Region23_P(P)) Then
        Region_PS = 2
        Exit Function
    Else
        Region_PS = 3
    End If
End Function

Private Function PS2T(P As Double, S As Double) As Double
    Dim Result, pi, eta As Double
    Result = 0
    Select Case Region_PS(P, S)
        Case 1
            Call InitFieldsreg1S
            For i = 0 To 19
                Result = Result + nreg1S(i) * P ^ ireg1S(i) * (S + 2) ^ jreg1S(i)
            Next
            PS2T = Result
        Case 2
            If P <= 4 Then
                Call InitFieldsreg2aS
                eta = S / 2
                For i = 0 To 45
                    Result = Result + nreg2aS(i) * P ^ ireg2aS(i) * (eta - 2) ^ jreg2aS(i)
                Next
                PS2T = Result
            ElseIf S >= 5.85 Then
                Call InitFieldsreg2bS
                eta = S / 0.7853
                For i = 0 To 43
                    Result = Result + nreg2bS(i) * P ^ ireg2bS(i) * (10 - eta) ^ jreg2bS(i)
                Next
                PS2T = Result
            Else
                Call InitFieldsreg2cS
                eta = S / 2.9251
                For i = 0 To 29
                    Result = Result + nreg2cS(i) * P ^ ireg2cS(i) * (2 - eta) ^ jreg2cS(i)
                Next
                PS2T = Result
            End If
        Case 3
            If S <= 4.41202148223476 Then
                Call InitFieldsreg3aS
                pi = P / 100
                eta = S / 4.4
                For i = 0 To 32
                    Result = Result + nreg3aS(i) * (pi + 0.24) ^ ireg3aS(i) * (eta - 0.703) ^ jreg3aS(i)
                Next
                PS2T = Result * 760
            Else
                Call InitFieldsreg3bS
                pi = P / 100
                eta = S / 5.3
                For i = 0 To 27
                    Result = Result + nreg3bS(i) * (pi + 0.76) ^ ireg3bS(i) * (eta - 0.818) ^ jreg3bS(i)
                Next
                PS2T = Result * 860
            End If
        Case 4
            PS2T = P2T(P)
        Case Else
            PS2T = -1
    End Select
End Function
'
'######################################################################################################################################
'API Function
'######################################################################################################################################
'
Public Function YW(Y As Double) As Double
    Dim T As Double
    T = P2T(Y)
    If T < 0 Then
        YW = -1
    Else
        YW = P2T(Y) - Tmin
    End If
End Function

Public Function WY(W As Double) As Double
    WY = T2P(W + Tmin)
End Function

Public Function YWM(Y As Double, W As Double) As Double
    YWM = PT2D(Y, W + Tmin)
End Function

Public Function YWB(Y As Double, W As Double) As Double
    YWB = 1# / YWM(Y, W)
End Function

Public Function YWN(Y As Double, W As Double) As Double
    YWN = PT2E(Y, W + Tmin)
End Function

Public Function YWH(Y As Double, W As Double) As Double
    YWH = PT2H(Y, W + Tmin)
End Function

Public Function YWS(Y As Double, W As Double) As Double
    YWS = PT2S(Y, W + Tmin)
End Function

Public Function YWDYB(Y As Double, W As Double) As Double
    YWDYB = PT2CP(Y, W + Tmin)
End Function

Public Function YWDRB(Y As Double, W As Double) As Double
    YWDRB = PT2CV(Y, W + Tmin)
End Function

Public Function YWDLN(Y As Double, W As Double) As Double
    YWDLN = PT2ETA(Y, W + Tmin)
End Function

Public Function YWYDN(Y As Double, W As Double) As Double
    Dim B As Double
    B = YWB(Y, W)
    If B < 0 Then
        YWYDN = -1
    Else
        YWYDN = PT2ETA(Y, W + Tmin) * B
    End If
End Function

Public Function YWDR(Y As Double, W As Double) As Double
    YWDR = PT2RAMD(Y, W + Tmin)
End Function

Public Function YHW(Y As Double, H As Double) As Double
    Dim T As Double
    T = PH2T(Y, H)
    If T < 0 Then
        YHW = -1
    Else
        YHW = T - Tmin
    End If
End Function

Public Function YSW(Y As Double, S As Double) As Double
    Dim T As Double
    T = PS2T(Y, S)
    If T < 0 Then
        YSW = -1
    Else
        YSW = T - Tmin
    End If
End Function

Public Function YGM(Y As Double, G As Double) As Double
    YGM = 1 / YGB(Y, G)
End Function

Public Function WGM(W As Double, G As Double) As Double
    WGM = 1 / WGB(W + Tmin, G)
End Function

Public Function YGB(Y As Double, G As Double) As Double
    YGB = PX2V(Y, G)
End Function

Public Function WGB(W As Double, G As Double) As Double
    WGB = TX2V(W + Tmin, G)
End Function

Public Function YGN(Y As Double, G As Double) As Double
    YGN = PX2E(Y, G)
End Function

Public Function WGN(W As Double, G As Double) As Double
    WGN = TX2E(W + Tmin, G)
End Function

Public Function YGH(Y As Double, G As Double) As Double
    YGH = PX2H(Y, G)
End Function

Public Function WGH(W As Double, G As Double) As Double
    WGH = TX2H(W + Tmin, G)
End Function

Public Function YGS(Y As Double, G As Double) As Double
    YGS = PX2S(Y, G)
End Function

Public Function WGS(W As Double, G As Double) As Double
    WGS = TX2S(W + Tmin, G)
End Function

Public Function YHG(Y As Double, H As Double) As Double
    Dim T As Double
    T = P2T(Y)
    If T < Tmin Or T > Tcrit Then
        YHG = -1
        Exit Function
    End If
    Dim H1 As Double, H2 As Double
    H1 = P2H_liq(Y)
    H2 = P2H_vap(Y)
    If (H - H1) / (H2 - H1) >= -0.5 Then
        YHG = (H - H1) / (H2 - H1)
    Else
        YHG = -1
    End If
End Function

Public Function YSG(Y As Double, S As Double) As Double
    Dim T As Double
    T = P2T(Y)
    If T < Tmin Or T > Tcrit Then
        YSG = -1
        Exit Function
    End If
    Dim S1 As Double, S2 As Double
    S1 = P2S_liq(Y)
    S2 = P2S_vap(Y)
    If (S - S1) / (S2 - S1) >= -0.5 Then
        YSG = (S - S1) / (S2 - S1)
    Else
        YSG = -1
    End If
End Function

'这个函数用插值法求中间值
'Public Function CZ(X1 As Double, Y1 As Double, X3 As Double, Y3 As Double, X2 As Double) As Double
'    CZ = Y1 + (Y3 - Y1) / (X3 - X1) * (X2 - X1)
'End Function
End Module
