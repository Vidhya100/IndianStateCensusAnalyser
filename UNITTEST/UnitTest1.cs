using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UNITTEST
{
    [TestClass]
    public class UnitTest1
    {
        string indianstateCensusHeaders = "State,Population,AreaInSquare,Density";
        string indianStateCensusFilePath = @"E:\c#\UNITTEST\CSVFiles\indianStateCenus.csv";
        string indianWrongCensusFilePath = @"E:\c#\UNITTEST\POCO\wrongHeaderStateCensusFilePath.csv";
        string wrongIndianStateCensusFileType = @"E:\c#\UNITTEST\CSVFiles\wrongIndianStateCensusFileType.txt";
        string wrongHeaderStateCensusFilePath = @"E:\c#\UNITTEST\CSVFiles\wrongHeaderStateCensusFilePath.csv";
        string delimiterIndianStateCensusFilePath = @"E:\c#\UNITTEST\CSVFiles\delimiterIndianStateCensusFilePath.csv";

        IndianStateCensusAnalyser.CSVAdapterFactory censusAnalyser;
        Dictionary<string, CensusDTO> totalRecords;

        [TestInitialize]
        public void SetUp()
        {
            censusAnalyser = new IndianStateCensusAnalyser.CSVAdapterFactory();
            totalRecords = new Dictionary<string, CensusDTO>();
        }
        //TC 1.1
        [TestMethod]        
        public void GivenStateCensusCSVFileShouldReturnCensusDataCount()
        {
            totalRecords = censusAnalyser.LoadCsvData(IndianStateCensusAnalyser.CensusAnalyser.Country.INDIA, 
                indianStateCensusFilePath, indianstateCensusHeaders);
            Assert.AreEqual(7, totalRecords.Count);
        }
        //TC 1.2
        [TestMethod]       
        public void GivenWrongFilePathShouldReturnCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() =>
            censusAnalyser.LoadCsvData(CensusAnalyser.Country.INDIA, indianWrongCensusFilePath, indianstateCensusHeaders));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
        }
        //TC 1.3
        [TestMethod]
        public void GivenWrongTypeShouldReturnsCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => 
            censusAnalyser.LoadCsvData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianstateCensusHeaders));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
        }
        //TC 1.4
        [TestMethod]
        public void GivenWrongDelimeterShouldReturnCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => 
            censusAnalyser.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterIndianStateCensusFilePath, indianstateCensusHeaders));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
        }
        //TC 1.5
        [TestMethod]
       
        public void GivenWrongHeaderShouldReturnsCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => 
            censusAnalyser.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCensusFilePath, indianstateCensusHeaders));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
        }
    }
}
