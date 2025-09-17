package runner;


import org.junit.platform.suite.api.*;

@Suite
@SelectClasspathResource("features")
@ConfigurationParameter(key = io.cucumber.junit.platform.engine.Constants.GLUE_PROPERTY_NAME, value = "steps,hooks")
@ConfigurationParameter(key = io.cucumber.junit.platform.engine.Constants.PLUGIN_PROPERTY_NAME, value = "pretty, summary")
public class CucumberTest {}
