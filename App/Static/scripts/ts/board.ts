import {BoardController} from "./classes/BoardController";

$(document).ready(function ()
{
	const controller = new BoardController();
	
	controller.testInitialize();
});