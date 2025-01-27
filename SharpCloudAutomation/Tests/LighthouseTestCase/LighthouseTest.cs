﻿using AngleSharp.Dom;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SharpCloudAutomation.PageObjects;
using SharpCloudAutomation.Tests.LoginTestCase;
using SharpCloudAutomation.Utilities;
using SharpCompress.Compressors.Xz;
using SoftAssertion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharpCloudAutomation.Tests.LighthouseTestCase
{
    public class LighthouseTest : Base
    {
        [Test]
        public void CompareLightHousePerformanceValues()
        {
            LighthouseActualValues lighthouseActualValues;

            SoftAssert softAssert = new SoftAssert();

            var scenarios = new JsonReader().GetScenarioes();

            foreach (var sc in scenarios ) 
            {
                if(sc.IsLogin)
                {
                    if(ConfigurationManager.AppSettings["env"] == "AutoInstance")
                    {
                        GetDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["AutoInstanceURL"]);
                    }
                    else if(ConfigurationManager.AppSettings["env"] == "Beta")
                    {
                        GetDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["BetaInstanceURL"]);
                    }
                    LoginPage loginPage = new LoginPage(GetDriver());
                    loginPage.validLogin(GetJsonData().ExtractInstanceDataJson("username"), GetJsonData().ExtractInstanceDataJson("password"));
                }
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                lighthouseActualValues = new LighthouseActualValues(sc.StoryUrl);
                ExtentTest performanceNode = CreateNode("Lighthouse performance values : " + sc.Scenario);
                performanceNode.Log(Status.Info, "Lighthouse Base value : " + sc.Performance);
                performanceNode.Log(Status.Info, "Lighthouse Actual value : " + lighthouseActualValues.Performance);
                softAssert.IsTrue(lighthouseActualValues.Performance >= sc.Performance);
            }
            softAssert.VerifyAll();
        }

        [Test]
        public void CompareLightHouseAccessibilityValues()
        {
            LighthouseActualValues lighthouseActualValues;

            SoftAssert softAssert = new SoftAssert();

            var scenarios = new JsonReader().GetScenarioes();

            foreach (var sc in scenarios)
            {
                if (sc.IsLogin)
                {
                    if (ConfigurationManager.AppSettings["env"] == "AutoInstance")
                    {
                        GetDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["AutoInstanceURL"]);
                    }
                    else if (ConfigurationManager.AppSettings["env"] == "Beta")
                    {
                        GetDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["BetaInstanceURL"]);
                    }
                    LoginPage loginPage = new LoginPage(GetDriver());
                    loginPage.validLogin(GetJsonData().ExtractInstanceDataJson("username"), GetJsonData().ExtractInstanceDataJson("password"));
                }
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                lighthouseActualValues = new LighthouseActualValues(sc.StoryUrl);
                ExtentTest accessibilityNode = CreateNode("Lighthouse accessibility values : " + sc.Scenario);
                accessibilityNode.Log(Status.Info, "Lighthouse Base value : " + sc.Accessibility);
                accessibilityNode.Log(Status.Info, "Lighthouse Actual value : " + lighthouseActualValues.Accessibility);
                softAssert.IsTrue(lighthouseActualValues.Accessibility >= sc.Accessibility);
            }
            softAssert.VerifyAll();
        }

        [Test]
        public void CompareLightHouseSeoValues()
        {
            LighthouseActualValues lighthouseActualValues;

            SoftAssert softAssert = new SoftAssert();

            var scenarios = new JsonReader().GetScenarioes();

            foreach (var sc in scenarios)
            {
                if (sc.IsLogin)
                {
                    if (ConfigurationManager.AppSettings["env"] == "AutoInstance")
                    {
                        GetDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["AutoInstanceURL"]);
                    }
                    else if (ConfigurationManager.AppSettings["env"] == "Beta")
                    {
                        GetDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["BetaInstanceURL"]);
                    }
                    LoginPage loginPage = new LoginPage(GetDriver());
                    loginPage.validLogin(GetJsonData().ExtractInstanceDataJson("username"), GetJsonData().ExtractInstanceDataJson("password"));
                }
                GetDriver().Navigate().GoToUrl(sc.StoryUrl);
                lighthouseActualValues = new LighthouseActualValues(sc.StoryUrl);
                ExtentTest seoNode = CreateNode("Lighthouse seo values : " + sc.Scenario);
                seoNode.Log(Status.Info, "Lighthouse Base value : " + sc.Seo);
                seoNode.Log(Status.Info, "Lighthouse Actual value : " + lighthouseActualValues.Seo);
                softAssert.IsTrue(lighthouseActualValues.Seo >= sc.Seo);
            }
            softAssert.VerifyAll();
        }
    }
}
