using System;
namespace if97
{
class program
{
	static void Main(string[] args)
	{
		double t1, t2, t3, p1, p2, p3, h1, h2, h3, s1, s2, s3;
		t1 = 300-273.15; t2 = 300-273.15; t3 = 500-273.15; p1 = 3.0; p2 = 80.0; p3 = 3.0;
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWB(p1, t1), YWB(p2, t2), YWB(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWN(p1, t1), YWN(p2, t2), YWN(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWH(p1, t1), YWH(p2, t2), YWH(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWS(p1, t1), YWS(p2, t2), YWS(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWDYB(p1, t1), YWDYB(p2, t2), YWDYB(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWDRB(p1, t1), YWDRB(p2, t2), YWDRB(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWDLN(p1, t1), YWDLN(p2, t2), YWDLN(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWYDN(p1, t1), YWYDN(p2, t2), YWYDN(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWDR(p1, t1), YWDR(p2, t2), YWDR(p3, t3));
		Console.WriteLine("");
		t1 = 300-273.15; t2 = 700-273.15; t3 = 700-273.15; p1 = 0.035; p2 = 0.035; p3 = 30;
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWB(p1, t1), YWB(p2, t2), YWB(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWN(p1, t1), YWN(p2, t2), YWN(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWH(p1, t1), YWH(p2, t2), YWH(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWS(p1, t1), YWS(p2, t2), YWS(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWDYB(p1, t1), YWDYB(p2, t2), YWDYB(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWDRB(p1, t1), YWDRB(p2, t2), YWDRB(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWDLN(p1, t1), YWDLN(p2, t2), YWDLN(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWYDN(p1, t1), YWYDN(p2, t2), YWYDN(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWDR(p1, t1), YWDR(p2, t2), YWDR(p3, t3));
		Console.WriteLine("");
		t1 = 650-273.15; t2 = 650-273.15; t3 = 750-273.15; p1 = 25.5837018; p2 = 22.2930643; p3 = 78.3095639;
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWB(p1, t1), YWB(p2, t2), YWB(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWN(p1, t1), YWN(p2, t2), YWN(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWH(p1, t1), YWH(p2, t2), YWH(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWS(p1, t1), YWS(p2, t2), YWS(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWDYB(p1, t1), YWDYB(p2, t2), YWDYB(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWDRB(p1, t1), YWDRB(p2, t2), YWDRB(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWDLN(p1, t1), YWDLN(p2, t2), YWDLN(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWYDN(p1, t1), YWYDN(p2, t2), YWYDN(p3, t3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YWDR(p1, t1), YWDR(p2, t2), YWDR(p3, t3));
		Console.WriteLine("");
		p1 = 3; p2 = 80;  p3 = 80; h1 = 500; h2 = 500; h3 = 1500; s1 = 0.5; s2 = 0.5; s3 = 3;
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YHW(p1, h1), YHW(p2, h2), YHW(p3, h3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YSW(p1, s1), YSW(p2, s2), YSW(p3, s3));
		Console.WriteLine("");
		p1 = 0.001; p2 = 3;  p3 = 3; h1 = 3000; h2 = 3000; h3 = 4000; s1 = 7.5; s2 = 8; s3 = 8;
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YHW(p1, h1), YHW(p2, h2), YHW(p3, h3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YSW(p1, s1), YSW(p2, s2), YSW(p3, s3));
		Console.WriteLine("");
		p1 = 5; p2 = 5;  p3 = 25; h1 = 3500; h2 = 4000; h3 = 3500; s1 = 6; s2 = 7.5; s3 = 6;
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YHW(p1, h1), YHW(p2, h2), YHW(p3, h3));
		Console.WriteLine("{0:N6}, {1:N6}, {2:N6}", YSW(p1, s1), YSW(p2, s2), YSW(p3, s3));
		Console.WriteLine("");
		Console.WriteLine("OK!");
		Console.ReadKey();
	}
	//区域3饱和参数与WASPCN计算结果有出入，误差不大
	const double Tcrit = 647.096;				// K
	const double Pcrit = 22.064;					// MPa
	const double Rhocrit = 322.0;				// kg/m^3
	const double Scrit = 4.41202148223476;		// J/kg-K (needed for backward eqn. in Region 3(a)(b)
	const double Ttrip = 273.16;					// K
	const double Ptrip = 0.000611656;			// MPa
	const double Tmin = 273.15;					// K
	const double Tmax = 1073.15;					// K
	const double Pmin = 0.000611213;				// MPa
	const double Pmax = 100.0;					// MPa
	const double Rgas = 0.461526;				// kJ/kg-K : mass based!
	const double MW = 0.018015268;				// kg/mol
	const double P23min = 16.529164252605;		// MPa
	const double T23min = 623.15;				// K
	const double T23max = 863.15;				// K
	static int[] ireg1 = new int[34]{ 0,  0, 0, 0, 0, 0, 0, 0,  1,  1,  1, 1, 1, 1,  2, 2, 2, 2,  2,  3, 3, 3,  4,  4,  4,  5,   8,  8,  21,  23,  29,  30,  31,  32};
	static int[] jreg1 = new int[34]{-2, -1, 0, 1, 2, 3, 4, 5, -9, -7, -1, 0, 1, 3, -3, 0, 1, 3, 17, -4, 0, 6, -5, -2, 10, -8, -11, -6, -29, -31, -38, -39, -40, -41};
	static double[] nreg1 = new double[34]{
		 0.14632971213167,    -0.84548187169114,    -3.756360367204,       3.3855169168385,     -0.95791963387872,
		 0.15772038513228,    -0.016616417199501,    8.1214629983568E-4,   2.8319080123804E-4,  -6.0706301565874E-4,
		-0.018990068218419,   -0.032529748770505,   -0.021841717175414,   -5.283835796993E-5,   -4.7184321073267E-4,
		-3.0001780793026E-4,   4.7661393906987E-5,  -4.4141845330846E-6,  -7.2694996297594E-16, -3.1679644845054E-5,
		-2.8270797985312E-6,  -8.5205128120103E-10, -2.2425281908E-6,     -6.5171222895601E-7,  -1.4341729937924E-13,
		-4.0516996860117E-7,  -1.2734301741641E-9,  -1.7424871230634E-10, -6.8762131295531E-19,  1.4478307828521E-20,
		 2.6335781662795E-23, -1.1947622640071E-23,  1.8228094581404E-24, -9.3537087292458E-26
	};
	static int[] j0reg2 = new int[9]{0, 1, -5, -4, -3, -2, -1, 2, 3};
	static double[] n0reg2 = new double[9]{
		 -9.6927686500217,  10.086655968018, -0.005608791128302, 0.071452738081455, -0.40710498223928,
		  1.4240819171444, -4.383951131945,  -0.28408632460772,  0.021268463753307
	};
	static int[] ireg2 = new int[43]{1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24};
	static int[] jreg2 = new int[43]{0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58};
	static double[] nreg2 = new double[43]{
		 -1.7731742473213E-3,  -0.017834862292358,   -0.045996013696365,   -0.057581259083432,   -0.05032527872793,
		 -3.3032641670203E-5,  -1.8948987516315E-4,  -3.9392777243355E-3,  -0.043797295650573,   -2.6674547914087E-5,
		  2.0481737692309E-8,   4.3870667284435E-7,  -3.227767723857E-5,   -1.5033924542148E-3,  -0.040668253562649,
		 -7.8847309559367E-10,  1.2790717852285E-8,   4.8225372718507E-7,   2.2922076337661E-6,  -1.6714766451061E-11,
		 -2.1171472321355E-3,  -23.895741934104,     -5.905956432427E-18,  -1.2621808899101E-6,  -0.038946842435739,
		  1.1256211360459E-11, -8.2311340897998,      1.9809712802088E-8,   1.0406965210174E-19, -1.0234747095929E-13,
		 -1.0018179379511E-9,  -8.0882908646985E-11,  0.10693031879409,    -0.33662250574171,     8.9185845355421E-25,
		  3.0629316876232E-13, -4.2002467698208E-6,  -5.9056029685639E-26,  3.7826947613457E-6,  -1.2768608934681E-15,
		  7.3087610595061E-29,  5.5414715350778E-17, -9.436970724121E-7
	};
	static int[] ireg3 = new int[40]{0, 0, 0, 0, 0,  0,  0,  0, 1, 1,  1,  1,  2, 2, 2, 2,  2,  2, 3, 3, 3,  3,  3, 4, 4, 4,  4, 5, 5,  5, 6, 6,  6, 7,  8, 9,  9, 10, 10, 11};
	static int[] jreg3 = new int[40]{0, 0, 1, 2, 7, 10, 12, 23, 2, 6, 15, 17,  0, 2, 6, 7, 22, 26, 0, 2, 4, 16, 26, 0, 2, 4, 26, 1, 3, 26, 0, 2, 26, 2, 26, 2, 26,  0,  1, 26};
	static double[] nreg3 = new double[40]{
		  1.0658070028513,    -15.732845290239,      20.944396974307,     -7.6867707878716,      2.6185947787954,
		 -2.808078114862,      1.2053369696517,     -8.4566812812502E-3,  -1.2654315477714,     -1.1524407806681,
		  0.88521043984318,   -0.64207765181607,     0.38493460186671,    -0.85214708824206,     4.8972281541877,
		 -3.0502617256965,     0.039420536879154,    0.12558408424308,    -0.2799932969871,      1.389979956946,
		 -2.018991502357,     -8.2147637173963E-3,  -0.47596035734923,     0.0439840744735,     -0.44476435428739,
		  0.90572070719733,    0.70522450087967,     0.10770512626332,    -0.32913623258954,    -0.50871062041158,
		 -0.022175400873096,   0.094260751665092,    0.16436278447961,    -0.013503372241348,   -0.014834345352472,
		  5.7922953628084E-4,  3.2308904703711E-03,  8.0964802996215E-5,  -1.6557679795037E-4,  -4.4923899061815E-5
	};
	static double[] nreg4 = new double[10]{
		 1167.0521452767, -724213.16703206, -17.073846940092,  12020.82470247,  -3232555.0322333,
		 14.91510861353,  -4823.2657361591,  405113.40542057, -0.23855557567849, 650.17534844798
	};
	static double[] nreg23 = new double[5]{348.05185628969, -1.1671859879975, 1.0192970039326E-03, 572.54459862746, 13.91883977887};
	static double[] n0visc = new double[4]{1.0, 0.978197, 0.579829, -0.202354};
	static int[] ivisc = new int[19]{0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 5, 6};
	static int[] jvisc = new int[19]{0, 1, 4, 5, 0, 1, 2, 3, 0, 1, 2, 0, 1, 2, 3, 0, 3, 1, 3};
	static double[] nvisc = new double[19]{
		  0.5132047, 0.3205656, -0.7782567,  0.1885447,  0.2151778,
		  0.7317883, 1.241044,   1.476783,  -0.2818107, -1.070786,
		 -1.263184,  0.1778064,  0.460504,   0.2340379, -0.4924179,
		 -0.0417661, 0.1600435, -0.01578386,-0.003629481
	};
	static double[] n0thcon = new double[4]{1.0, 6.978267, 2.599096, -0.998254};
	static double[, ] nthcon = new double[5, 6]{
			{ 1.3293046, -0.40452437, 0.2440949,  0.018660751, -0.12961068,  0.044809953},
			{ 1.7018363, -2.2156845,  1.6511057, -0.76736002,   0.37283344, -0.1120316},
			{ 5.2246158, -10.124111,  4.9874687, -0.27297694,  -0.43083393,  0.13333849},
			{ 8.7127675, -9.5000611,  4.3786606, -0.91783782,   0.0,         0.0},
			{-1.8525999,  0.9340469,  0.0,        0.0,          0.0,         0.0}
	};
	static int[] ireg1H = new int[20]{0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 3, 4, 5, 6};
	static int[] jreg1H = new int[20]{0, 1, 2, 6, 22, 32, 0, 1, 2, 3, 4, 10, 32, 10, 32, 10, 32, 32, 32, 32};
	static double[] nreg1H = new double[20]{
		 -0.23872489924521E3,   0.40421188637945E3,    0.11349746881718E3,  -0.58457616048039E1,   -0.1528548241314E-3,
		 -0.10866707695377E-5, -0.13391744872602E2,    0.43211039183559E2,  -0.54010067170506E2,    0.30535892203916E2,
		 -0.65964749423638E1,   0.93965400878363E-2,   0.1157364750534E-6,  -0.25858641282073E-4,  -0.40644363084799E-8,
		  0.66456186191635E-7,  0.80670734103027E-10, -0.93477771213947E-12, 0.58265442020601E-14, -0.15020185953503E-16
	};
	static int[] ireg2aH = new int[34]{0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7};
	static int[] jreg2aH = new int[34]{0, 1, 2, 3, 7, 20, 0, 1, 2, 3, 7, 9, 11, 18, 44, 0, 2, 7, 36, 38, 40, 42, 44, 24, 44, 12, 32, 44, 32, 36, 42, 34, 44, 28};
	static double[] nreg2aH = new double[34]{
		  0.10898952318288E4,   0.84951654495535E3, -0.1078174809183E3,    0.33153654801263E2, -0.74232016790248E1,
		  0.11765048724356E2,   0.1844574935579E1,  -0.41792700549624E1,   0.62478196935812E1, -0.17344563108114E2,
		 -0.20058176862096E3,   0.27196065473796E3, -0.45511318285818E3,   0.30919688604755E4,  0.25226640357872E6,
		 -0.61707422868339E-2, -0.31078046629583,    0.11670873077107E2,   0.12812798404046E9, -0.98554909623276E9,
		  0.28224546973002E10, -0.35948971410703E10, 0.17227349913197E10, -0.13551334240775E5,  0.1284873466465E8,
		  0.13865724283226E1,   0.23598832556514E6, -0.13105236545054E8,   0.73999835474766E4, -0.5519669703006E6,
		  0.37154085996233E7,   0.1912772923966E5,  -0.41535164835634E6,  -0.62459855192507E2
	};
	static int[] ireg2bH = new int[38]{0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 5, 5, 5, 6, 7, 7, 9, 9};
	static int[] jreg2bH = new int[38]{0, 1, 2, 12, 18, 24, 28, 40, 0, 2, 6, 12, 18, 24, 28, 40, 2, 8, 18, 40, 1, 2, 12, 24, 2, 12, 18, 24, 28, 40, 18, 24, 40, 28, 2, 28, 1, 40};
	static double[] nreg2bH = new double[38]{
		  0.14895041079516E4,    0.74307798314034E3,  -0.97708318797837E2,   0.24742464705674E1,  -0.63281320016026,
		  0.11385952129658E1,   -0.47811863648625,     0.85208123431544E-2,  0.93747147377932,     0.33593118604916E1,
		  0.33809355601454E1,    0.16844539671904,     0.73875745236695,    -0.47128737436186,     0.15020273139707,
		 -0.2176411421975E-2,   -0.21810755324761E-1, -0.10829784403677,    -0.46333324635812E-1,  0.71280351959551E-4,
		  0.11032831789999E-3,   0.18955248387902E-3,  0.30891541160537E-2,  0.13555504554949E-2,  0.28640237477456E-6,
		 -0.10779857357512E-4,  -0.76462712454814E-4,  0.14052392818316E-4, -0.31083814331434E-4, -0.10302738212103E-5,
		  0.2821728163504E-6,    0.12704902271945E-5,  0.73803353468292E-7, -0.11030139238909E-7, -0.81456365207833E-13,
		 -0.25180545682962E-10, -0.17565233969407E-17, 0.86934156344163E-14
	};
	static int[] ireg2cH = new int[23]{-7, -7, -6, -6, -5, -5, -2, -2, -1, -1, 0, 0, 1, 1, 2, 6, 6, 6, 6, 6, 6, 6, 6};
	static int[] jreg2cH = new int[23]{0, 4, 0, 2, 0, 2, 0, 1, 0, 2, 0, 1, 4, 8, 4, 0, 1, 4, 10, 12, 16, 20, 22};
	static double[] nreg2cH = new double[23]{
		 -0.32368398555242E13,  0.73263350902181E13,  0.35825089945447E12, -0.5834013185159E12,  -0.1078306821747E11,
		  0.20825544563171E11,  0.61074783564516E6,   0.8597772253558E6,   -0.2574572360417E5,    0.31081088422714E5,
		  0.12082315865936E4,   0.48219755109255E3,   0.37966001272486E1,  -0.10842984880077E2,  -0.4536417267666E-1,
		  0.14559115658698E-12, 0.1126159740723E-11, -0.17804982240686E-10, 0.12324579690832E-6, -0.11606921130984E-5,
		  0.27846367088554E-4, -0.59270038474176E-3,  0.12918582991878E-2
	};
	static int[] ireg3aH = new int[31]{-12, -12, -12, -12, -12, -12, -12, -12, -10, -10, -10, -8, -8, -8, -8, -5, -3, -2, -2, -2, -1, -1, 0, 0, 1, 3, 3, 4, 4, 10, 12};
	static int[] jreg3aH = new int[31]{0, 1, 2, 6, 14, 16, 20, 22, 1, 5, 12, 0, 2, 4, 10, 2, 0, 1, 3, 4, 0, 2, 0, 1, 1, 0, 1, 0, 3, 4, 5};
	static double[] nreg3aH = new double[31]{
		-0.133645667811215E-6, 0.455912656802978E-5,-0.146294640700979E-4, 0.639341312970080E-2, 0.372783927268847E3,
		-0.718654377460447E4,  0.573494752103400E6, -0.267569329111439E7, -0.334066283302614E-4,-0.245479214069597E-1,
		 0.478087847764996E2,  0.764664131818904E-5,0.128350627676972E-2, 0.171219081377331E-1,-0.851007304583213E1,
		-0.136513461629781E-1,-0.384460997596657E-5, 0.337423807911655E-2,-0.551624873066791,    0.729202277107470,
		-0.992522757376041E-2,-0.119308831407288,    0.793929190615421,    0.454270731799386,    0.209998591259910,
		-0.642109823904738E-2,-0.235155868604540E-1, 0.252233108341612E-2,-0.764885133368119E-2, 0.136176427574291E-1,
		-0.133027883575669E-1
	};
	static int[] ireg3bH = new int[33]{-12, -12, -10, -10, -10, -10, -10, -8, -8, -8, -8, -8, -6, -6, -6, -4, -4, -3, -2, -2, -1, -1, -1, -1, -1, -1, 0, 0, 1, 3, 5, 6, 8};
	static int[] jreg3bH = new int[33]{0, 1, 0, 1, 5, 10, 12, 0, 1, 2, 4, 10, 0, 1, 2, 0, 1,5,0, 4, 2, 4, 6, 10, 14, 16, 0, 2, 1, 1, 1, 1, 1};
	static double[] nreg3bH = new double[33]{
		 0.323254573644920E-4,-0.127575556587181E-3,-0.475851877356068E-3, 0.156183014181602E-2, 0.105724860113781,
		-0.858514221132534E2,  0.724140095480911E3,  0.296475810273257E-2,-0.592721983365988E-2,-0.126305422818666E-1,
		-0.115716196364853,    0.849000969739595E2, -0.108602260086615E-1, 0.154304475328851E-1, 0.750455441524466E-1,
		 0.252520973612982E-1,-0.602507901232996E-1,-0.307622221350501E1, -0.574011959864879E-1, 0.503471360939849E1,
		-0.925081888584834,    0.391733882917546E1, -0.773146007130190E2,  0.949308762098587E4, -0.141043719679409E7,
		 0.849166230819026E7,  0.861095729446704,    0.323346442811720,    0.873281936020439,   -0.436653048526683,
		 0.286596714529479,   -0.131778331276228,    0.676682064330275E-2
	};
	static int[] ireg1S = new int[20]{0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 4};
	static int[] jreg1S = new int[20]{0, 1, 2, 3, 11, 31, 0, 1, 2, 3, 12, 31, 0, 1, 2, 9, 31, 10, 32, 32};
	static double[] nreg1S = new double[20]{
		  0.17478268058307E3,    0.34806930892873E2,   0.65292584978455E1,   0.33039981775489,     -0.19281382923196E-6,
		 -0.24909197244573E-22, -0.261076364893322,    0.22592965981586,    -0.64256463395226E-1,  0.78876289270526E-2,
		  0.35672110607366E-9,   0.17332496994895E-23, 0.56608900654837E-3, -0.32635483139717E-3,  0.44778286690632E-4,
		 -0.51322156908507E-9,  -0.42522657042207E-25, 0.26400441360689E-12, 0.78124600459723E-28,-0.30732199903668E-30
	};
	static double[] ireg2aS = new double[46]{
		 -1.5, -1.5,  -1.5,  -1.5,  -1.5, -1.5,  -1.25, -1.25, -1.25, -1.0,
		 -1.0, -1.0,  -1.0,  -1.0,  -1.0, -0.75, -0.75, -0.5,  -0.5,  -0.5,
		 -0.5, -0.25, -0.25, -0.25, -0.25, 0.25,  0.25,  0.25,  0.25,  0.5,
		  0.5,  0.5,   0.5,   0.5,   0.5,  0.5,   0.75,  0.75,  0.75,  0.75,
		  1.0,  1.0,   1.25, 1.25,   1.5,  1.5
	};
	static int[] jreg2aS = new int[46]{
		 -24, -23, -19, -13, -11, -10, -19, -15, -6, -26,
		 -21, -17, -16, -9,  -8,  -15, -14, -26, -13, -9,
		 -7,  -27, -25, -11, -6,    1,   4,   8,  11,  0,
		  1,    5,   6,  10, 14,   16,   0,   4,   9, 17,
		  7,   18,   3,  15,  5,   18
	};
	static double[] nreg2aS = new double[46]{
		 -0.39235983861984E6,   0.5152657382727E6,   0.40482443161048E5,  -0.32193790923902E3,   0.96961424218694E2,
		 -0.22867846371773E2,  -0.44942914124357E6, -0.50118336020166E4,   0.35684463560015,     0.4423533584819E5,
		 -0.13673388811708E5,   0.42163260207864E6,  0.22516925837475E5,   0.47442144865646E3,  -0.14931130797647E3,
		 -0.19781126320452E6,  -0.2355439947076E5,  -0.19070616302076E5,   0.55375669883164E5,   0.38293691437363E4,
		 -0.60391860580567E3,   0.19363102620331E4,  0.4266064369861E4,   -0.59780638872718E4,  -0.70401463926862E3,
		  0.33836784107553E3,   0.20862786635187E2,  0.33834172656196E-1, -0.43124428414893E-4,  0.16653791356412E3,
		 -0.13986292055898E3,  -0.78849547999872,    0.72132411753872E-1, -0.59754839398283E-2, -0.12141358953904E-4,
		  0.23227096733871E-6, -0.10538463566194E2,  0.20718925496502E1,  -0.72193155260427E-1,  0.2074988708112E-6,
		 -0.18340657911379E-1,  0.29036272348696E-6, 0.21037527893619,     0.25681239729999E-3, -0.12799002933781E-1,
		 -0.82198102652018E-5
	};
	static int[] ireg2bS = new int[44]{-6, -6, -5, -5, -4, -4, -4, -3, -3, -3, -3, -2, -2, -2, -2, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 5, 5, 5};
	static int[] jreg2bS = new int[44]{0, 11, 0, 11, 0, 1, 11, 0, 1, 11, 12, 0, 1, 6, 10, 0, 1, 5, 8, 9, 0, 1, 2, 4, 5, 6, 9, 0, 1, 2, 3, 7, 8, 0, 1, 5, 0, 1, 3, 0, 1, 0, 1, 2};
	static double[] nreg2bS = new double[44]{
		  0.31687665083497E6,   0.20864175881858E2,  -0.39859399803599E6,  -0.21816058518877E2,   0.22369785194242E6,
		 -0.27841703445817E4,   0.9920743607148E1,   -0.75197512299157E5,   0.29708605951158E4,  -0.34406878548526E1,
		  0.38815564249115,     0.1751129508575E5,   -0.14237112854449E4,   0.10943803364167E1,   0.89971619308495,
		 -0.33759740098958E4,   0.47162885818355E3,  -0.19188241993679E1,   0.41078580492196,    -0.33465378172097,
		  0.13870034777505E4,  -0.40663326195838E3,   0.4172734715961E2,    0.21932549434532E1,  -0.10320050009077E1,
		  0.35882943516703,     0.52511453726066E-2,  0.12838916450705E2,  -0.28642437219381E1,   0.56912683664855,
		 -0.99962954584931E-1, -0.32632037778459E-2,  0.23320922576723E-3, -0.1533480985745,      0.29072288239902E-1,
		  0.37534702741167E-3,  0.17296691702411E-2, -0.38556050844504E-3, -0.35017712292608E-4, -0.14566393631492E-4,
		  0.56420857267269E-5,  0.41286150074605E-7, -0.20684671118824E-7,  0.16409393674725E-8
	};
	static int[] ireg2cS = new int[30]{-2, -2, -1, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7, 7, 7, 7, 7};
	static int[] jreg2cS = new int[30]{0, 1, 0, 0, 1, 2, 3, 0, 1, 3, 4, 0, 1, 2, 0, 1, 5, 0, 1, 4, 0, 1, 2, 0, 1, 0, 1, 3, 4, 5};
	static double[] nreg2cS = new double[30]{
		  0.90968501005365E3,    0.2404566708842E4,    -0.5916232638713E3,    0.54145404128074E3,  -0.27098308411192E3,
		  0.97976525097926E3,   -0.46966772959435E3,    0.14399274604723E2,  -0.19104204230429E2,   0.53299167111971E1,
		 -0.21252975375934E2,   -0.3114733441376,       0.60334840894623,    -0.42764839702509E-1,  0.58185597255259E-2,
		 -0.14597008284753E-1,   0.56631175631027E-2,  -0.76155864584577E-4,  0.22440342919332E-3, -0.12561095013413E-4,
		  0.63323132660934E-6,  -0.20541989675375E-5,   0.36405370390082E-7, -0.29759897789215E-8,  0.10136618529763E-7,
		  0.59925719692351E-11, -0.20677870105164E-10, -0.20874278181886E-10, 0.10162166825089E-9, -0.16429828281347E-9
	};
	static int[] ireg3aS = new int[33]{-12, -12,-10,-10,-10,-10,-8,-8,-8,-8, -6, -6, -6, -5, -5, -5, -4, -4, -4, -2, -2, -1, -1, 0, 0, 0, 1, 2, 2, 3, 8, 8, 10};
	static int[] jreg3aS = new int[33]{28, 32, 4, 10, 12, 14, 5, 7, 8, 28, 2, 6, 32, 0, 14, 32, 6, 10, 36, 1, 4, 1, 6, 0, 1, 4, 0, 0, 3, 2, 0, 1, 2};
	static double[] nreg3aS = new double[33]{
		 0.150042008263875E10, -0.159397258480424E12,  0.502181140217975E-3, -0.672057767855466E2,  0.145058545404456E4,
		-0.823889534888890E4,  -0.154852214233853,     0.112305046746695E2,  -0.297000213482822E2,  0.438565132635495E11,
		 0.137837838635464E-2, -0.297478527157462E1,   0.971777947349413E13, -0.571527767052398E-4, 0.288307949778420E5,
		-0.744428289262703E14,  0.128017324848921E2,  -0.368275545889071E3,   0.664768904779177E16, 0.449359251958880E-1,
		-0.422897836099655E1,  -0.240614376434179,    -0.474341365254924E1,   0.724093999126110,    0.923874349695897,
		 0.399043655281015E1,   0.384066651868009E-1, -0.359344365571848E-2, -0.735196448821653,    0.188367048396131,
		 0.141064266818704E-3, -0.257418501496337E-2,  0.123220024851555E-2
	};
	static int[] ireg3bS = new int[28]{-12, -12, -12, -12, -8, -8, -8, -6, -6, -6, -5, -5, -5, -5, -5, -4, -3, -3, -2, 0, 2, 3, 4, 5, 6, 8, 12, 14};
	static int[] jreg3bS = new int[28]{1, 3, 4, 7, 0, 1, 3, 0, 2, 4, 0, 1, 2, 4, 6, 12, 1, 6, 2, 0, 1, 1, 0, 24, 0, 3, 1, 2};
	static double[] nreg3bS = new double[28]{
		 0.527111701601660,   -0.401317830052742E2,  0.153020073134484E3,  -0.224799398218827E4, -0.193993484669048,
		-0.140467557893768E1,  0.426799878114024E2,  0.752810643416743,     0.226657238616417E2, -0.622873556909932E3,
		-0.660823667935396,    0.841267087271658,   -0.253717501764397E2,   0.485708963532948E3,  0.880531517490555E3,
		 0.265015592794626E7, -0.35928715025783,    -0.656991567673753E3,   0.241768149185367E1,  0.856873461222588,
		 0.655143675313458,   -0.213535213206406,    0.562974957606348E-2, -0.316955725450471E15,-0.699997000152457E-3,
		 0.119845803210767E-1, 0.193848122022095E-4,-0.215095749182309E-4
	};
	static double[] reg2b2c = new double[5]{905.84278514723, -0.67955786399241, 1.2809002730136E-04, 2652.6571908428, 4.5257578905948};
	static double[] reg3a3b = new double[4]{2014.64004206875, 3.74696550136983, -2.19921901054187E-02, 8.7513168600995E-05};

	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	static double gammareg1(double tau, double pi)
	{
		int i; double gammareg1 = 0;
		for (i = 0; i <= 33; i++)
		{ gammareg1 = gammareg1 + nreg1[i] * Math.Pow((7.1 - pi), ireg1[i]) * Math.Pow((tau - 1.222), jreg1[i]); }
		return gammareg1;
	}

	static double gammapireg1(double tau, double pi)
	{
		int i; double gammapireg1 = 0;
		for (i = 0; i <= 33; i++)
		{ gammapireg1 = gammapireg1 - nreg1[i] * ireg1[i] * Math.Pow((7.1 - pi), (ireg1[i] - 1)) * Math.Pow((tau - 1.222), jreg1[i]); }
		return gammapireg1;
	}

	static double gammapipireg1(double tau, double pi)
	{
		int i; double gammapipireg1 = 0;
		for (i = 0; i <= 33; i++)
		{ gammapipireg1 = gammapipireg1 + nreg1[i] * ireg1[i] * (ireg1[i] - 1) * Math.Pow((7.1 - pi), (ireg1[i] - 2)) * Math.Pow((tau - 1.222), jreg1[i]); }
		return gammapipireg1;
	}

	static double gammataureg1(double tau, double pi)
	{
		int i; double gammataureg1 = 0;
		for (i = 0; i <= 33; i++)
		{ gammataureg1 = gammataureg1 + nreg1[i] * Math.Pow((7.1 - pi), ireg1[i]) * jreg1[i] * Math.Pow((tau - 1.222), (jreg1[i] - 1)); }
		return gammataureg1;
	}

	static double gammatautaureg1(double tau, double pi)
	{
		int i; double gammatautaureg1 = 0;
		for (i = 0; i <= 33; i++)
		{ gammatautaureg1 = gammatautaureg1 + nreg1[i] * Math.Pow((7.1 - pi), ireg1[i]) * jreg1[i] * (jreg1[i] - 1) * Math.Pow((tau - 1.222), (jreg1[i] - 2)); }
		return gammatautaureg1;
	}

	static double gammapitaureg1(double tau, double pi)
	{
		int i; double gammapitaureg1 = 0;
		for (i = 0; i <= 33; i++)
		{ gammapitaureg1 = gammapitaureg1 - nreg1[i] * ireg1[i] * Math.Pow((7.1 - pi), (ireg1[i] - 1)) * jreg1[i] * Math.Pow((tau - 1.222), (jreg1[i] - 1)); }
		return gammapitaureg1;
	}

	static double gamma0reg2(double tau, double pi)
	{
		int i; double gamma0reg2 = Math.Log(pi);
		for (i = 0; i <= 8; i++)
		{ gamma0reg2 = gamma0reg2 + n0reg2[i] * Math.Pow(tau, j0reg2[i]); }
		return gamma0reg2;
	}

	static double gamma0pireg2(double tau, double pi)
	{
		return 1 / pi;
	}

	static double gamma0pipireg2(double tau, double pi)
	{
		return -1 / (pi * pi);
	}

	static double gamma0taureg2(double tau, double pi)
	{
		int i; double gamma0taureg2 = 0;
		for (i = 0; i <= 8; i++)
		{ gamma0taureg2 = gamma0taureg2 + n0reg2[i] * j0reg2[i] * Math.Pow(tau, (j0reg2[i] - 1)); }
		return gamma0taureg2;
	}

	static double gamma0tautaureg2(double tau, double pi)
	{
		int i; double gamma0tautaureg2 = 0;
		for (i = 0; i <= 8; i++)
		{ gamma0tautaureg2 = gamma0tautaureg2 + n0reg2[i] * j0reg2[i] * (j0reg2[i] - 1) * Math.Pow(tau, (j0reg2[i] - 2)); }
		return gamma0tautaureg2;
	}

	static double gamma0pitaureg2(double tau, double pi)
	{
		return 0;
	}

	static double gammarreg2(double tau, double pi)
	{
		int i; double gammarreg2 = 0;
		for (i = 0; i <= 42; i++)
		{ gammarreg2 = gammarreg2 + nreg2[i] * Math.Pow(pi, ireg2[i]) * Math.Pow((tau - 0.5), jreg2[i]); }
		return gammarreg2;
	}

	static double gammarpireg2(double tau, double pi)
	{
		int i; double gammarpireg2 = 0;
		for (i = 0; i <= 42; i++)
		{ gammarpireg2 = gammarpireg2 + nreg2[i] * ireg2[i] * Math.Pow(pi, (ireg2[i] - 1)) * Math.Pow((tau - 0.5), jreg2[i]); }
		return gammarpireg2;
	}

	static double gammarpipireg2(double tau, double pi)
	{
		int i; double gammarpipireg2 = 0;
		for (i = 0; i <= 42; i++)
		{ gammarpipireg2 = gammarpipireg2 + nreg2[i] * ireg2[i] * (ireg2[i] - 1) * Math.Pow(pi, (ireg2[i] - 2)) * Math.Pow((tau - 0.5), jreg2[i]); }
		return gammarpipireg2;
	}

	static double gammartaureg2(double tau, double pi)
	{
		int i; double gammartaureg2 = 0;
		for (i = 0; i <= 42; i++)
		{ gammartaureg2 = gammartaureg2 + nreg2[i] * Math.Pow(pi, ireg2[i]) * jreg2[i] * Math.Pow((tau - 0.5), (jreg2[i] - 1)); }
		return gammartaureg2;
	}

	static double gammartautaureg2(double tau, double pi)
	{
		int i; double gammartautaureg2 = 0;
		for (i = 0; i <= 42; i++)
		{ gammartautaureg2 = gammartautaureg2 + nreg2[i] * Math.Pow(pi, ireg2[i]) * jreg2[i] * (jreg2[i] - 1) * Math.Pow((tau - 0.5), (jreg2[i] - 2)); }
		return gammartautaureg2;
	}

	static double gammarpitaureg2(double tau, double pi)
	{
		int i; double gammarpitaureg2 = 0;
		for (i = 0; i <= 42; i++)
		{ gammarpitaureg2 = gammarpitaureg2 + nreg2[i] * ireg2[i] * Math.Pow(pi, (ireg2[i] - 1)) * jreg2[i] * Math.Pow((tau - 0.5), (jreg2[i] - 1)); }
		return gammarpitaureg2;
	}

	static double fireg3(double tau, double delta)
	{
		int i; double fireg3 = nreg3[0] * Math.Log(delta);
		for (i = 1; i <= 39; i++)
		{ fireg3 = fireg3 + nreg3[i] * Math.Pow(delta, ireg3[i]) * Math.Pow(tau, jreg3[i]); }
		return fireg3;
	}

	static double fideltareg3(double tau, double delta)
	{
		int i; double fideltareg3 = nreg3[0] / delta;
		for (i = 1; i <= 39; i++)
		{ fideltareg3 = fideltareg3 + nreg3[i] * ireg3[i] * Math.Pow(delta, (ireg3[i] - 1)) * Math.Pow(tau, jreg3[i]); }
		return fideltareg3;
	}

	static double fideltadeltareg3(double tau, double delta)
	{
		int i; double fideltadeltareg3 = -nreg3[0] / (delta * delta);
		for (i = 1; i <= 39; i++)
		{ fideltadeltareg3 = fideltadeltareg3 + nreg3[i] * ireg3[i] * (ireg3[i] - 1) * Math.Pow(delta, (ireg3[i] - 2)) * Math.Pow(tau, jreg3[i]); }
		return fideltadeltareg3;
	}

	static double fitaureg3(double tau, double delta)
	{
		int i; double fitaureg3 = 0;
		for (i = 1; i <= 39; i++)
		{ fitaureg3 = fitaureg3 + nreg3[i] * Math.Pow(delta, ireg3[i]) * jreg3[i] * Math.Pow(tau, (jreg3[i] - 1)); }
		return fitaureg3;
	}

	static double fitautaureg3(double tau, double delta)
	{
		int i; double fitautaureg3 = 0;
		for (i = 1; i <= 39; i++)
		{ fitautaureg3 = fitautaureg3 + nreg3[i] * Math.Pow(delta, ireg3[i]) * jreg3[i] * (jreg3[i] - 1) * Math.Pow(tau, (jreg3[i] - 2)); }
		return fitautaureg3;
	}

	static double fideltataureg3(double tau, double delta)
	{
		int i; double fideltataureg3 = 0;
		for (i = 1; i <= 39; i++)
		{ fideltataureg3 = fideltataureg3 + nreg3[i] * ireg3[i] * Math.Pow(delta, (ireg3[i] - 1)) * jreg3[i] * Math.Pow(tau, (jreg3[i] - 1)); }
		return fideltataureg3;
	}

	static double psivisc(double tau, double delta)
	{
		int i; double psi0 = 0; double psi1 = 0;
		for (i = 0; i <= 3; i++)
		{ psi0 = psi0 + n0visc[i] * Math.Pow(tau, i); }
		psi0 = 1 / (Math.Pow(tau, 0.5) * psi0);
		for (i = 0; i <= 18; i++)
		{ psi1 = psi1 + nvisc[i] * Math.Pow((delta - 1), ivisc[i]) * Math.Pow((tau - 1), jvisc[i]); }
		psi1 = Math.Exp(delta * psi1);
		return psi0 * psi1;
	}

	static double T2P(double T)
	{
		if (T < Tmin || T > Tcrit) return -1;
		double theta, A, B, C;
		theta = T + nreg4[8] / (T - nreg4[9]);
		A = theta * theta + nreg4[0] * theta + nreg4[1];
		B = nreg4[2] * theta * theta + nreg4[3] * theta + nreg4[4];
		C = nreg4[5] * theta * theta + nreg4[6] * theta + nreg4[7];
		return Math.Pow((2 * C / (-B + Math.Pow((B * B - 4 * A * C), 0.5))), 4);
	}

	static double P2T(double P)
	{
		if (P < Pmin || P > Pcrit) return -1;
		double beta, D, E, F, G;
		beta = Math.Pow(P, 0.25);
		E = beta * beta + nreg4[2] * beta + nreg4[5];
		F = nreg4[0] * beta * beta + nreg4[3] * beta + nreg4[6];
		G = nreg4[1] * beta * beta + nreg4[4] * beta + nreg4[7];
		D = 2 * G / (-F - Math.Pow((F * F - 4 * E * G), 0.5));
		return 0.5 * (nreg4[9] + D - Math.Pow((Math.Pow((nreg4[9] + D), 2) - 4 * (nreg4[8] + nreg4[9] * D)), 0.5));
	}

	static double Region23_T(double T)
	{
		return nreg23[0] + nreg23[1] * T + nreg23[2] * T * T;
	}

	static double Region23_P(double P)
	{
		return nreg23[3] + Math.Pow(((P - nreg23[4]) / nreg23[2]), 0.5);
	}

	static int Region_PT(double P, double T)
	{
		if (P < Pmin || P > Pmax || T < Tmin || T > Tmax) return -1;
		else if (T > T23min)
		{
			if (P < 16.5292) return 2;
			else if (P > Region23_T(T)) return 3;
			else return 2;
		}
		else
		{
			if (P > T2P(T)) return 1;
			else if (P < T2P(T)) return 2;
			else return 4;
		}
	}

	static double PT2Vreg1(double P, double T)
	{
		double tau, pi;
		tau = 1386 / T;
		pi = P / 16.53;
		return Rgas * T * pi * gammapireg1(tau, pi) / (P * 1000);
	}

	static double PT2Vreg2(double P, double T)
	{
		double tau, pi;
		tau = 540 / T;
		pi = P;
		return Rgas * T * pi * (gamma0pireg2(tau, pi) + gammarpireg2(tau, pi)) / (P * 1000);
	}

	static double PT2Dreg3(double P, double T)
	{
		double DensOld, tau, delta, derivprho, DensNew, diffdens;
		int i;
		if (T < Tcrit && P < T2P(T)) DensOld = 100;
		else DensOld = 600;
		tau = Tcrit / T;
		for (i = 1; i <= 1000; i++)
		{
			delta = DensOld / Rhocrit;
			derivprho = Rgas * 1000 * T / Rhocrit * (2 * DensOld * fideltareg3(tau, delta) + Math.Pow(DensOld, 2) / Rhocrit * fideltadeltareg3(tau, delta));
			DensNew = DensOld + (P * 1000000 - Rgas * 1000 * T * Math.Pow(DensOld, 2) / Rhocrit * fideltareg3(tau, delta)) / derivprho;
			diffdens = Math.Abs(DensNew - DensOld);
			if (diffdens < 0.000005) return DensNew;
			DensOld = DensNew;
		}
		return -1;
	}

	static double PT2D(double P, double T)
	{
		switch (Region_PT(P, T))
		{
			case 1:
				return 1 / PT2Vreg1(P, T);
			case 2:
				return 1 / PT2Vreg2(P, T);
			case 3:
				return PT2Dreg3(P, T);
		}
		return -1;
	}

	static double PT2Ereg1(double P, double T)
	{
		double tau, pi;
		tau = 1386 / T;
		pi = P / 16.53;
		return Rgas * T * (tau * gammataureg1(tau, pi) - pi * gammapireg1(tau, pi));
	}

	static double PT2Ereg2(double P, double T)
	{
		double tau, pi;
		tau = 540 / T;
		pi = P;
		return Rgas * T * (tau * (gamma0taureg2(tau, pi) + gammartaureg2(tau, pi)) - pi * (gamma0pireg2(tau, pi) + gammarpireg2(tau, pi)));
	}

	static double TD2Ereg3(double T, double D)
	{
		double tau, delta;
		tau = Tcrit / T;
		delta = D / Rhocrit;
		return Rgas * T * tau * fitaureg3(tau, delta);
	}

	static double PT2E(double P, double T)
	{
		switch (Region_PT(P, T))
		{
			case 1:
				return PT2Ereg1(P, T);
			case 2:
				return PT2Ereg2(P, T);
			case 3:
				return TD2Ereg3(T, PT2Dreg3(P, T));
		}
		return -1;
	}

	static double PT2Hreg1(double P, double T)
	{
		double tau, pi;
		tau = 1386 / T;
		pi = P / 16.53;
		return Rgas * T * tau * gammataureg1(tau, pi);
	}

	static double PT2Hreg2(double P, double T)
	{
		double tau, pi;
		tau = 540 / T;
		pi = P;
		return Rgas * T * tau * (gamma0taureg2(tau, pi) + gammartaureg2(tau, pi));
	}

	static double TD2Hreg3(double T, double D)
	{
		double tau, delta;
		tau = Tcrit / T;
		delta = D / Rhocrit;
		return Rgas * T * (tau * fitaureg3(tau, delta) + delta * fideltareg3(tau, delta));
	}

	static double PT2H(double P, double T)
	{
		switch (Region_PT(P, T))
		{
			case 1:
				return PT2Hreg1(P, T);
			case 2:
				return PT2Hreg2(P, T);
			case 3:
				return TD2Hreg3(T, PT2Dreg3(P, T));
		}
		return -1;
	}

	static double PT2Sreg1(double P, double T)
	{
		double tau, pi;
		tau = 1386 / T;
		pi = P / 16.53;
		return Rgas * (tau * gammataureg1(tau, pi) - gammareg1(tau, pi));
	}

	static double PT2Sreg2(double P, double T)
	{
		double tau, pi;
		tau = 540 / T;
		pi = P;
		return Rgas * (tau * (gamma0taureg2(tau, pi) + gammartaureg2(tau, pi)) - (gamma0reg2(tau, pi) + gammarreg2(tau, pi)));
	}

	static double TD2Sreg3(double T, double D)
	{
		double tau, delta;
		tau = Tcrit / T;
		delta = D / Rhocrit;
		return Rgas * (tau * fitaureg3(tau, delta) - fireg3(tau, delta));
	}

	static double PT2S(double P, double T)
	{
		switch (Region_PT(P, T))
		{
			case 1:
				return PT2Sreg1(P, T);
			case 2:
				return PT2Sreg2(P, T);
			case 3:
				return TD2Sreg3(T, PT2Dreg3(P, T));
		}
		return -1;
	}

	static double PT2CPreg1(double P, double T)
	{
		double tau, pi;
		tau = 1386 / T;
		pi = P / 16.53;
		return -1 * Rgas * tau * tau * gammatautaureg1(tau, pi);
	}

	static double PT2CPreg2(double P, double T)
	{
		double tau, pi;
		tau = 540 / T;
		pi = P;
		return -1 * Rgas * tau * tau * (gamma0tautaureg2(tau, pi) + gammartautaureg2(tau, pi));
	}

	static double TD2CPreg3(double T, double D)
	{
		double tau, delta;
		tau = Tcrit / T;
		delta = D / Rhocrit;
		return Rgas * (-tau * tau * fitautaureg3(tau, delta) + Math.Pow((delta * fideltareg3(tau, delta) - delta * tau * fideltataureg3(tau, delta)), 2) / (2 * delta * fideltareg3(tau, delta) + delta * delta * fideltadeltareg3(tau, delta)));
	}

	static double PT2CP(double P, double T)
	{
		switch (Region_PT(P, T))
		{
			case 1:
				return PT2CPreg1(P, T);
			case 2:
				return PT2CPreg2(P, T);
			case 3:
				return TD2CPreg3(T, PT2Dreg3(P, T));
		}
		return -1;
	}

	static double PT2CVreg1(double P, double T)
	{
		double tau, pi;
		tau = 1386 / T;
		pi = P / 16.53;
		return Rgas * (-tau * tau * gammatautaureg1(tau, pi) + Math.Pow((gammapireg1(tau, pi) - tau * gammapitaureg1(tau, pi)), 2) / gammapipireg1(tau, pi));
	}

	static double PT2CVreg2(double P, double T)
	{
		double tau, pi;
		tau = 540 / T;
		pi = P;
		return Rgas * (-tau * tau * (gamma0tautaureg2(tau, pi) + gammartautaureg2(tau, pi)) - Math.Pow((1 + pi * gammarpireg2(tau, pi) - tau * pi * gammarpitaureg2(tau, pi)), 2) / (1 - pi * pi * gammarpipireg2(tau, pi)));
	}

	static double TD2CVreg3(double T, double D)
	{
		double tau, delta;
		tau = Tcrit / T;
		delta = D / Rhocrit;
		return Rgas * (-tau * tau * fitautaureg3(tau, delta));
	}

	static double PT2CV(double P, double T)
	{
		switch (Region_PT(P, T))
		{
			case 1:
				return PT2CVreg1(P, T);
			case 2:
				return PT2CVreg2(P, T);
			case 3:
				return TD2CVreg3(T, PT2Dreg3(P, T));
		}
		return -1;
	}

	static double PT2ETA(double P, double T)
	{
		if (T >= Tmin && T <= Tmax && P > Pmin && P <= Pmax) return 0.000055071 * psivisc(647.226 / T, PT2D(P, T) / 317.763);
		else return -1;
	}

	static double lambthcon(double P, double T, double tau, double delta)
	{
		double lamb0, lamb1, lamb2, taus, pis, dpidtau, ddeltadpi, deltas;
		int i, j;
		lamb0 = 0; lamb1 = 0;
		for (i = 0; i <= 3; i++) lamb0 = lamb0 + n0thcon[i] * Math.Pow(tau, i);
		lamb0 = 1 / (Math.Pow(tau, 0.5) * lamb0);
		for (i = 0; i <= 4; i++)
		{
			for (j = 0; j <= 5; j++) lamb1 = lamb1 + nthcon[i, j] * Math.Pow((tau - 1), i) * Math.Pow((delta - 1), j);
		}
		lamb1 = Math.Exp(delta * lamb1);
		switch (Region_PT(P, T))
		{
			case 1:
				taus = 1386 / T;
				pis = P / 16.53;
				dpidtau = (647.226 * 165.3 * (gammapitaureg1(taus, pis) * 1386 - gammapireg1(taus, pis) * T)) / (221.15 * T * T * gammapipireg1(taus, pis));
				ddeltadpi = -(22115000 * gammapipireg1(taus, pis)) / (317.763 * Rgas * 1000 * T * Math.Pow(gammapireg1(taus, pis), 2));
				break;
			case 2:
				taus = 540 / T;
				pis = P;
				dpidtau = (647.226 * 10 * ((gamma0pitaureg2(taus, pis) + gammarpitaureg2(taus, pis)) * 540 - (gamma0pireg2(taus, pis) + gammarpireg2(taus, pis)) * T)) / (221.15 * T * T * (gamma0pipireg2(taus, pis) + gammarpipireg2(taus, pis)));
				ddeltadpi = -(22115000 * (gamma0pipireg2(taus, pis) + gammarpipireg2(taus, pis))) / (317.763 * Rgas * 1000 * T * Math.Pow((gamma0pireg2(taus, pis) + gammarpireg2(taus, pis)), 2));
				break;
			case 3:
				taus = 647.096 / T;
				deltas = delta * 317.763 / Rhocrit;
				dpidtau = (647.226 * Rgas * 1000 * Math.Pow((delta * 317.763), 2) * (fideltareg3(taus, deltas) - (647.096 / T) * fideltataureg3(taus, deltas))) / (22115000 * Rhocrit);
				ddeltadpi = (22115000 * Rhocrit) / (317.763 * delta * 317.763 * Rgas * 1000 * T * (2 * fideltareg3(taus, deltas) + (delta * 317.763 / Rhocrit) * fideltadeltareg3(taus, deltas)));
				break;
			default:
				dpidtau = 0;
				ddeltadpi = 0;
				break;
		}
		lamb2 = 0.0013848 / psivisc(tau, delta) * Math.Pow((tau * delta), (-2)) * dpidtau * dpidtau * Math.Pow((delta * ddeltadpi), 0.4678) * Math.Pow(delta, 0.5) * Math.Exp(-18.66 * Math.Pow((1 / tau - 1), 2) - Math.Pow((delta - 1), 4));
		return lamb0 * lamb1 + lamb2;
	}

	static double PT2RAMD(double P, double T)
	{
		if (T >= Tmin && T <= Tmax && P > Pmin && P <= Pmax) return 0.4945 * lambthcon(P, T, 647.226 / T, PT2D(P, T) / 317.763);
		else return -1;
	}

	static double T2D_liq(double T)
	{
		if (T >= Tmin && T <= T23min) return 1 / PT2Vreg1(T2P(T), T);
		else if (T > T23min && T <= Tcrit) return PT2Dreg3(T2P(T), T);
		else return -1;
	}

	static double T2D_vap(double T)
	{
		if (T >= Tmin && T <= T23min) return 1 / PT2Vreg2(T2P(T), T);
		else if (T > T23min && T <= Tcrit) return PT2Dreg3(T2P(T) - 0.00001, T);
		else return -1;
	}

	static double P2D_liq(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return 1 / PT2Vreg1(P, T);
		else if (T > T23min && T <= Tcrit) return PT2Dreg3(P + 0.00001, T);
		else return -1;
	}

	static double P2D_vap(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return 1 / PT2Vreg2(T2P(T), T);
		else if (T > T23min && T <= Tcrit) return PT2Dreg3(T2P(T) - 0.00001, T);
		else return -1;
	}

	static double TX2V(double T, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = 1 / T2D_liq(T);
		R2 = 1 / T2D_vap(T);
		return R1 + (R2 - R1) * X;
	}

	static double PX2V(double P, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = 1 / P2D_liq(P);
		R2 = 1 / P2D_vap(P);
		return R1 + (R2 - R1) * X;
	}

	static double T2E_liq(double T)
	{
		if (T >= Tmin && T <= T23min) return PT2Ereg1(T2P(T), T);
		else if (T > T23min && T <= Tcrit) return TD2Ereg3(T, PT2Dreg3(T2P(T), T));
		else return -1;
	}

	static double T2E_vap(double T)
	{
		if (T >= Tmin && T <= T23min) return PT2Ereg2(T2P(T), T);
		else if (T > T23min && T <= Tcrit) return TD2Ereg3(T, PT2Dreg3(T2P(T) - 0.00001, T));
		else return -1;
	}

	static double P2E_liq(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return PT2Ereg1(P, T);
		else if (T > T23min && T <= Tcrit) return TD2Ereg3(T, PT2Dreg3(P + 0.00001, T));
		else return -1;
	}

	static double P2E_vap(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return PT2Ereg2(P, T);
		else if (T > T23min && T <= Tcrit) return TD2Ereg3(T, PT2Dreg3(P - 0.00001, T));
		else return -1;
	}

	static double TX2E(double T, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = T2E_liq(T);
		R2 = T2E_vap(T);
		return R1 + (R2 - R1) * X;
	}

	static double PX2E(double P, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = P2E_liq(P);
		R2 = P2E_vap(P);
		return R1 + (R2 - R1) * X;
	}

	static double T2H_liq(double T)
	{
		if (T >= Tmin && T <= T23min) return PT2Hreg1(T2P(T), T);
		else if (T > T23min && T <= Tcrit) return TD2Hreg3(T, PT2Dreg3(T2P(T), T));
		else return -1;
	}

	static double T2H_vap(double T)
	{
		if (T >= Tmin && T <= T23min) return PT2Hreg2(T2P(T), T);
		else if (T > T23min && T <= Tcrit) return TD2Hreg3(T, PT2Dreg3(T2P(T) - 0.00001, T));
		else return -1;
	}

	static double P2H_liq(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return PT2Hreg1(P, T);
		else if (T > T23min && T <= Tcrit) return TD2Hreg3(T, PT2Dreg3(P + 0.00001, T));
		else return -1;
	}

	static double P2H_vap(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return PT2Hreg2(P, T);
		else if (T > T23min && T <= Tcrit) return TD2Hreg3(T, PT2Dreg3(P - 0.00001, T));
		else return -1;
	}

	static double TX2H(double T, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = T2H_liq(T);
		R2 = T2H_vap(T);
		return R1 + (R2 - R1) * X;
	}

	static double PX2H(double P, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = P2H_liq(P);
		R2 = P2H_vap(P);
		return R1 + (R2 - R1) * X;
	}

	static double T2S_liq(double T)
	{
		if (T >= Tmin && T <= T23min) return PT2Sreg1(T2P(T), T);
		else if (T > T23min && T <= Tcrit) return TD2Sreg3(T, PT2Dreg3(T2P(T), T));
		else return -1;
	}

	static double T2S_vap(double T)
	{
		if (T >= Tmin && T <= T23min) return PT2Sreg2(T2P(T), T);
		else if (T > T23min && T <= Tcrit) return TD2Sreg3(T, PT2Dreg3(T2P(T) - 0.00001, T));
		else return -1;
	}

	static double P2S_liq(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return PT2Sreg1(P, T);
		else if (T > T23min && T <= Tcrit) return TD2Sreg3(T, PT2Dreg3(P + 0.00001, T));
		else return -1;
	}

	static double P2S_vap(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return PT2Sreg2(P, T);
		else if (T > T23min && T <= Tcrit) return TD2Sreg3(T, PT2Dreg3(P - 0.00001, T));
		else return -1;
	}

	static double TX2S(double T, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = T2S_liq(T);
		R2 = T2S_vap(T);
		return R1 + (R2 - R1) * X;
	}

	static double PX2S(double P, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = P2S_liq(P);
		R2 = P2S_vap(P);
		return R1 + (R2 - R1) * X;
	}

	static double T2CP_liq(double T)
	{
		if (T >= Tmin && T <= T23min) return PT2CPreg1(T2P(T), T);
		else if (T > T23min && T <= Tcrit) return TD2CPreg3(T, PT2Dreg3(T2P(T), T));
		else return -1;
	}

	static double T2CP_vap(double T)
	{
		if (T >= Tmin && T <= T23min) return PT2CPreg2(T2P(T), T);
		else if (T > T23min && T <= Tcrit) return TD2CPreg3(T, PT2Dreg3(T2P(T) - 0.00001, T));
		else return -1;
	}

	static double P2CP_liq(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return PT2CPreg1(P, T);
		else if (T > T23min && T <= Tcrit) return TD2CPreg3(T, PT2Dreg3(P + 0.00001, T));
		else return -1;
	}

	static double P2CP_vap(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return PT2CPreg2(P, T);
		else if (T > T23min && T <= Tcrit) return TD2CPreg3(T, PT2Dreg3(P - 0.00001, T));
		else return -1;
	}

	static double TX2CP(double T, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = T2CP_liq(T);
		R2 = T2CP_vap(T);
		return R1 + (R2 - R1) * X;
	}

	static double PX2CP(double P, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = P2CP_liq(P);
		R2 = P2CP_vap(P);
		return R1 + (R2 - R1) * X;
	}

	static double T2CV_liq(double T)
	{
		if (T >= Tmin && T <= T23min) return PT2CVreg1(T2P(T), T);
		else if (T > T23min && T <= Tcrit) return TD2CVreg3(T, PT2Dreg3(T2P(T), T));
		else return -1;
	}

	static double T2CV_vap(double T)
	{
		if (T >= Tmin && T <= T23min) return PT2CVreg2(T2P(T), T);
		else if (T > T23min && T <= Tcrit) return TD2CVreg3(T, PT2Dreg3(T2P(T) - 0.00001, T));
		else return -1;
	}

	static double P2CV_liq(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return PT2CVreg1(P, T);
		else if (T > T23min && T <= Tcrit) return TD2CVreg3(T, PT2Dreg3(P + 0.00001, T));
		else return -1;
	}

	static double P2CV_vap(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return PT2CVreg2(P, T);
		else if (T > T23min && T <= Tcrit) return TD2CVreg3(T, PT2Dreg3(P - 0.00001, T));
		else return -1;
	}

	static double TX2CV(double T, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = T2CV_liq(T);
		R2 = T2CV_vap(T);
		return R1 + (R2 - R1) * X;
	}

	static double PX2CV(double P, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = P2CV_liq(P);
		R2 = P2CV_vap(P);
		return R1 + (R2 - R1) * X;
	}

	static double T2ETA_liq(double T)
	{
		if (T >= Tmin && T <= T23min) return 0.000055071 * psivisc(647.226 / T, 1 / PT2Vreg1(T2P(T), T) / 317.763);
		else if (T > T23min && T <= Tcrit) return 0.000055071 * psivisc(647.226 / T, PT2Dreg3(T2P(T), T) / 317.763);
		else return -1;
	}

	static double T2ETA_vap(double T)
	{
		if (T >= Tmin && T <= T23min) return 0.000055071 * psivisc(647.226 / T, 1 / PT2Vreg2(T2P(T), T) / 317.763);
		else if (T > T23min && T <= Tcrit) return 0.000055071 * psivisc(647.226 / T, PT2Dreg3(T2P(T) - 0.00001, T) / 317.763);
		else return -1;
	}

	static double P2ETA_liq(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return 0.000055071 * psivisc(647.226 / T, 1 / PT2Vreg1(P, T) / 317.763);
		else if (T > T23min && T <= Tcrit) return 0.000055071 * psivisc(647.226 / T, PT2Dreg3(P + 0.00001, T) / 317.763);
		else return -1;
	}

	static double P2ETA_vap(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return 0.000055071 * psivisc(647.226 / T, 1 / PT2Vreg2(P, T) / 317.763);
		else if (T > T23min && T <= Tcrit) return 0.000055071 * psivisc(647.226 / T, PT2Dreg3(P - 0.00001, T) / 317.763);
		else return -1;
	}

	static double TX2ETA(double T, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = T2ETA_liq(T);
		R2 = T2ETA_vap(T);
		return R1 + (R2 - R1) * X;
	}

	static double PX2ETA(double P, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = P2ETA_liq(P);
		R2 = P2ETA_vap(P);
		return R1 + (R2 - R1) * X;
	}

	static double T2RAMD_liq(double T)
	{
		double P = T2P(T);
		if (T >= Tmin && T <= T23min) return 0.4945 * lambthcon(P, T, 647.226 / T, 1 / PT2Vreg1(P, T) / 317.763);
		else if (T > T23min && T <= Tcrit) return 0.4945 * lambthcon(P, T, 647.226 / T, PT2Dreg3(P, T) / 317.763);
		else return -1;
	}

	static double T2RAMD_vap(double T)
	{
		double P = T2P(T);
		if (T >= Tmin && T <= T23min) return 0.4945 * lambthcon(P - 0.0001 * P, T, 647.226 / T, 1 / PT2Vreg2(P, T) / 317.763);
		else if (T > T23min && T <= Tcrit) return 0.4945 * lambthcon(P - 0.00001, T, 647.226 / T, PT2Dreg3(P - 0.00001, T) / 317.763);
		else return -1;
	}

	static double P2RAMD_liq(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return 0.4945 * lambthcon(P, T, 647.226 / T, 1 / PT2Vreg1(P, T) / 317.763);
		else if (T > T23min && T <= Tcrit) return 0.4945 * lambthcon(P + 0.00001, T, 647.226 / T, PT2Dreg3(P + 0.00001, T) / 317.763);
		else return -1;
	}

	static double P2RAMD_vap(double P)
	{
		double T = P2T(P);
		if (T >= Tmin && T <= T23min) return 0.4945 * lambthcon(P - 0.0001 * P, T, 647.226 / T, 1 / PT2Vreg2(P, T) / 317.763);
		else if (T > T23min && T <= Tcrit) return 0.4945 * lambthcon(P - 0.00001, T, 647.226 / T, PT2Dreg3(P - 0.00001, T) / 317.763);
		else return -1;
	}

	static double TX2RAMD(double T, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = T2RAMD_liq(T);
		R2 = T2RAMD_vap(T);
		return R1 + (R2 - R1) * X;
	}

	static double PX2RAMD(double P, double X)
	{
		if (X < 0 || X > 1) return -1;
		double R1, R2;
		R1 = P2RAMD_liq(P);
		R2 = P2RAMD_vap(P);
		return R1 + (R2 - R1) * X;
	}

	static int Region_PH(double P, double H)
	{
		if (P < Pmin || P > Pmax) return -1;
		else if (H > PT2H(P, Tmax) || H < PT2H(P, Tmin)) return -1;
		double Hliq, Hvap;
		Hliq = P2H_liq(P);
		Hvap = P2H_vap(P);
		if (P <= Pcrit)
		{
			if (H >= Hliq && H <= Hvap) return 4;
		}
		if (P <= P23min)
		{
			if (H <= Hliq) return 1;
			else if (H >= Hvap) return 2;
			else return 4;
		}
		else if (H <= PT2H(P, T23min)) return 1;
		else if (H >= PT2H(P, Region23_P(P))) return 2;
		else return 3;
	}

	static double PH2T(double P, double H)
	{
		double PH2T, pi, eta;
		int i;
		PH2T = 0;
		switch (Region_PH(P, H))
		{
			case 1:
				eta = H / 2500;
				for (i = 0; i <= 19; i++) PH2T = PH2T + nreg1H[i] * Math.Pow(P, ireg1H[i]) * Math.Pow((eta + 1), jreg1H[i]);
				return PH2T;
			case 2:
				if (P <= 4)
				{
					eta = H / 2000;
					for (i = 0; i <= 33; i++) PH2T = PH2T + nreg2aH[i] * Math.Pow(P, ireg2aH[i]) * Math.Pow((eta - 2.1), jreg2aH[i]);
					return PH2T;
				}
				else if (H >= reg2b2c[3] + Math.Pow(((P - reg2b2c[4]) / reg2b2c[2]), 0.5))
				{
					eta = H / 2000;
					for (i = 0; i <= 37; i++) PH2T = PH2T + nreg2bH[i] * Math.Pow((P - 2), ireg2bH[i]) * Math.Pow((eta - 2.6), jreg2bH[i]);
					return PH2T;
				}
				else
				{
					eta = H / 2000;
					for (i = 0; i <= 22; i++) PH2T = PH2T + nreg2cH[i] * Math.Pow((P + 25), ireg2cH[i]) * Math.Pow((eta - 1.8), jreg2cH[i]);
					return PH2T;
				}
			case 3:
				if (H <= reg3a3b[0] + reg3a3b[1] * P + reg3a3b[2] * P * P + reg3a3b[3] * P * P * P)
				{
					pi = P / 100;
					eta = H / 2300;
					for (i = 0; i <= 30; i++) PH2T = PH2T + nreg3aH[i] * Math.Pow((pi + 0.24), ireg3aH[i]) * Math.Pow((eta - 0.615), jreg3aH[i]);
					return PH2T * 760;
				}
				else
				{
					pi = P / 100;
					eta = H / 2800;
					for (i = 0; i <= 32; i++) PH2T = PH2T + nreg3bH[i] * Math.Pow((pi + 0.298), ireg3bH[i]) * Math.Pow((eta - 0.72), jreg3bH[i]);
					return PH2T * 860;
					
				}
			case 4:
				return P2T(P);
			default:
				return -1;
		}
	}

	static int Region_PS(double P, double S)
	{
		if (P < Pmin || P > Pmax) return -1;
		else if (S > PT2S(P, Tmax) || S < PT2S(P, Tmin)) return -1;
		double Sliq, Svap;
		Sliq = P2S_liq(P);
		Svap = P2S_vap(P);
		if (P <= Pcrit)
		{
			if (S >= Sliq && S <= Svap) return 4;
		}
		if (P <= P23min)
		{
			if (S <= Sliq) return 1;
			else if (S >= Svap) return 2;
			else return 4;
		}
		else if (S <= PT2S(P, T23min)) return 1;
		else if (S >= PT2S(P, Region23_P(P))) return 2;
		else return 3;
	}

	static double PS2T(double P, double S)
	{
		double PS2T, pi, eta;
		int i;
		PS2T = 0;
		switch (Region_PS(P, S))
		{
			case 1:
				for (i = 0; i <= 19; i++) PS2T = PS2T + nreg1S[i] * Math.Pow(P, ireg1S[i]) * Math.Pow((S + 2), jreg1S[i]);
				return PS2T;
			case 2:
				if (P <= 4)
				{
					eta = S / 2;
					for (i = 0; i <= 45; i++) PS2T = PS2T + nreg2aS[i] * Math.Pow(P, ireg2aS[i]) * Math.Pow((eta - 2), jreg2aS[i]);
					return PS2T;
				}
				else if (S >= 5.85)
				{
					eta = S / 0.7853;
					for (i = 0; i <= 43; i++) PS2T = PS2T + nreg2bS[i] * Math.Pow(P, ireg2bS[i]) * Math.Pow((10 - eta), jreg2bS[i]);
					return PS2T;
				}
				else
				{
					eta = S / 2.9251;
					for (i = 0; i <= 29; i++) PS2T = PS2T + nreg2cS[i] * Math.Pow(P, ireg2cS[i]) * Math.Pow((2 - eta), jreg2cS[i]);
					return PS2T;
				}
			case 3:
				if (S <= 4.41202148223476)
				{
					pi = P / 100;
					eta = S / 4.4;
					for (i = 0; i <= 32; i++) PS2T = PS2T + nreg3aS[i] * Math.Pow((pi + 0.24), ireg3aS[i]) * Math.Pow((eta - 0.703), jreg3aS[i]);
					return PS2T * 760;
				}
				else
				{
					pi = P / 100;
					eta = S / 5.3;
					for (i = 0; i <= 32; i++) PS2T = PS2T + nreg3bS[i] * Math.Pow((pi + 0.76), ireg3bS[i]) * Math.Pow((eta - 0.818), jreg3bS[i]);
					return PS2T * 860;
				}
			case 4:
				return P2T(P);
			default:
				return -1;
		}
	}

	////////////////////////
	//    API Function    //
	////////////////////////

	static public double YW(double Y)
	{
		if (P2T(Y) < 0) return -1;
		else return P2T(Y) - Tmin;
	}

	static public double WY(double W)
	{
		return T2P(W + Tmin);
	}

	static public double YWM(double Y, double W)
	{
		return PT2D(Y, W + Tmin);
	}

	static public double YWB(double Y, double W)
	{
		return 1 / YWM(Y, W);
	}

	static public double YWN(double Y, double W)
	{
		return PT2E(Y, W + Tmin);
	}

	static public double YWH(double Y, double W)
	{
		return PT2H(Y, W + Tmin);
	}

	static public double YWS(double Y, double W)
	{
		return PT2S(Y, W + Tmin);
	}

	static public double YWDYB(double Y, double W)
	{
		return PT2CP(Y, W + Tmin);
	}

	static public double YWDRB(double Y, double W)
	{
		return PT2CV(Y, W + Tmin);
	}

	static public double YWDLN(double Y, double W)
	{
		return PT2ETA(Y, W + Tmin);
	}

	static public double YWYDN(double Y, double W)
	{
		if (YWB(Y, W) < 0) return -1;
		else return PT2ETA(Y, W + Tmin) * YWB(Y, W);
	}

	static public double YWDR(double Y, double W)
	{
		return PT2RAMD(Y, W + Tmin);
	}

	static public double YHW(double Y, double H)
	{
		if (PH2T(Y, H) < 0) return -1;
		else return PH2T(Y, H) - Tmin;
	}

	static public double YSW(double Y, double S)
	{
		if (PS2T(Y, S) < 0) return -1;
		else return PS2T(Y, S) - Tmin;
	}

	static public double YGM(double Y, double G)
	{
		return 1 / YGB(Y, G);
	}

	static public double WGM(double W, double G)
	{
		return 1 / WGB(W + Tmin, G);
	}

	static public double YGB(double Y, double G)
	{
		return PX2V(Y, G);
	}

	static public double WGB(double W, double G)
	{
		return TX2V(W + Tmin, G);
	}

	static public double YGN(double Y, double G)
	{
		return PX2E(Y, G);
	}

	static public double WGN(double W, double G)
	{
		return TX2E(W + Tmin, G);
	}

	static public double YGH(double Y, double G)
	{
		return PX2H(Y, G);
	}

	static public double WGH(double W, double G)
	{
		return TX2H(W + Tmin, G);
	}

	static public double YGS(double Y, double G)
	{
		return PX2S(Y, G);
	}

	static public double WGS(double W, double G)
	{
		return TX2S(W + Tmin, G);
	}

	static public double YHG(double Y, double H)
	{
		double T = P2T(Y);
		if (T < Tmin || T > Tcrit) return -1;
		double H1, H2;
		H1 = P2H_liq(Y);
		H2 = P2H_vap(Y);
		if ((H - H1) / (H2 - H1) >= -0.5) return (H - H1) / (H2 - H1);
		else return -1;
	}

	static public double YSG(double Y, double S)
	{
		double T = P2T(Y);
		if (T < Tmin || T > Tcrit) return -1;
		double S1, S2;
		S1 = P2S_liq(Y);
		S2 = P2S_vap(Y);
		if ((S - S1) / (S2 - S1) >= -0.5) return (S - S1) / (S2 - S1);
		else return -1;
	}
}
}
