#include <stdio.h>
#include "if97.h"

int main(int argc, char *argv[])
{
	double t1, t2, t3, p1, p2, p3, h1, h2, h3, s1, s2, s3;
	t1 = 300-273.15; t2 = 300-273.15; t3 = 500-273.15; p1 = 3.0; p2 = 80.0; p3 = 3.0;
	printf("Region1\n");
	printf("t1 = %f, t2 = %f, t3 = %f, p1=%f, p2=%f, p3=%f\n", t1, t2, t3, p1, p2, p3);
	printf("B:%f, %f, %f\n", YWB(p1, t1), YWB(p2, t2), YWB(p3, t3));
	printf("N:%f, %f, %f\n", YWN(p1, t1), YWN(p2, t2), YWN(p3, t3));
	printf("H:%f, %f, %f\n", YWH(p1, t1), YWH(p2, t2), YWH(p3, t3));
	printf("S:%f, %f, %f\n", YWS(p1, t1), YWS(p2, t2), YWS(p3, t3));
	printf("DYB:%f, %f, %f\n", YWDYB(p1, t1), YWDYB(p2, t2), YWDYB(p3, t3));
	printf("DRB:%f, %f, %f\n", YWDRB(p1, t1), YWDRB(p2, t2), YWDRB(p3, t3));
	printf("DLN:%f, %f, %f\n", YWDLN(p1, t1), YWDLN(p2, t2), YWDLN(p3, t3));
	printf("YDSN:%f, %f, %f\n", YWYDN(p1, t1), YWYDN(p2, t2), YWYDN(p3, t3));
	printf("DR:%f, %f, %f\n\n", YWDR(p1, t1), YWDR(p2, t2), YWDR(p3, t3));
	t1 = 300-273.15; t2 = 700-273.15; t3 = 700-273.15; p1 = 0.035; p2 = 0.035; p3 = 30;
	printf("Region2\n");
	printf("t1 = %f, t2 = %f, t3 = %f, p1=%f, p2=%f, p3=%f\n", t1, t2, t3, p1, p2, p3);
	printf("B:%f, %f, %f\n", YWB(p1, t1), YWB(p2, t2), YWB(p3, t3));
	printf("N:%f, %f, %f\n", YWN(p1, t1), YWN(p2, t2), YWN(p3, t3));
	printf("H:%f, %f, %f\n", YWH(p1, t1), YWH(p2, t2), YWH(p3, t3));
	printf("S:%f, %f, %f\n", YWS(p1, t1), YWS(p2, t2), YWS(p3, t3));
	printf("DYB:%f, %f, %f\n", YWDYB(p1, t1), YWDYB(p2, t2), YWDYB(p3, t3));
	printf("DRB:%f, %f, %f\n", YWDRB(p1, t1), YWDRB(p2, t2), YWDRB(p3, t3));
	printf("DLN:%f, %f, %f\n", YWDLN(p1, t1), YWDLN(p2, t2), YWDLN(p3, t3));
	printf("YDSN:%f, %f, %f\n", YWYDN(p1, t1), YWYDN(p2, t2), YWYDN(p3, t3));
	printf("DR:%f, %f, %f\n\n", YWDR(p1, t1), YWDR(p2, t2), YWDR(p3, t3));
	t1 = 650-273.15; t2 = 650-273.15; t3 = 750-273.15; p1 = 25.5837018; p2 = 22.2930643; p3 = 78.3095639;
	printf("Region3\n");
	printf("t1 = %f, t2 = %f, t3 = %f, p1=%f, p2=%f, p3=%f\n", t1, t2, t3, p1, p2, p3);
	printf("B:%f, %f, %f\n", YWB(p1, t1), YWB(p2, t2), YWB(p3, t3));
	printf("N:%f, %f, %f\n", YWN(p1, t1), YWN(p2, t2), YWN(p3, t3));
	printf("H:%f, %f, %f\n", YWH(p1, t1), YWH(p2, t2), YWH(p3, t3));
	printf("S:%f, %f, %f\n", YWS(p1, t1), YWS(p2, t2), YWS(p3, t3));
	printf("DYB:%f, %f, %f\n", YWDYB(p1, t1), YWDYB(p2, t2), YWDYB(p3, t3));
	printf("DRB:%f, %f, %f\n", YWDRB(p1, t1), YWDRB(p2, t2), YWDRB(p3, t3));
	printf("DLN:%f, %f, %f\n", YWDLN(p1, t1), YWDLN(p2, t2), YWDLN(p3, t3));
	printf("YDSN:%f, %f, %f\n", YWYDN(p1, t1), YWYDN(p2, t2), YWYDN(p3, t3));
	printf("DR:%f, %f, %f\n\n", YWDR(p1, t1), YWDR(p2, t2), YWDR(p3, t3));
	p1 = 3; p2 = 80;  p3 = 80; h1 = 500; h2 = 500; h3 = 1500; s1 = 0.5; s2 = 0.5; s3 = 3;
	printf("Region1\n");
	printf("YHW:%f, %f, %f\n", YHW(p1, h1), YHW(p2, h2), YHW(p3, h3));
	printf("YSW:%f, %f, %f\n", YSW(p1, s1), YSW(p2, s2), YSW(p3, s3));
	p1 = 0.001; p2 = 3;  p3 = 3; h1 = 3000; h2 = 3000; h3 = 4000; s1 = 7.5; s2 = 8; s3 = 8;
	printf("Region2\n");
	printf("YHW:%f, %f, %f\n", YHW(p1, h1), YHW(p2, h2), YHW(p3, h3));
	printf("YSW:%f, %f, %f\n", YSW(p1, s1), YSW(p2, s2), YSW(p3, s3));
	p1 = 5; p2 = 5;  p3 = 25; h1 = 3500; h2 = 4000; h3 = 3500; s1 = 6; s2 = 7.5; s3 = 6;
	printf("Region3\n");
	printf("YHW:%f, %f, %f\n", YHW(p1, h1), YHW(p2, h2), YHW(p3, h3));
	printf("YSW:%f, %f, %f\n", YSW(p1, s1), YSW(p2, s2), YSW(p3, s3));
	return 0;
}