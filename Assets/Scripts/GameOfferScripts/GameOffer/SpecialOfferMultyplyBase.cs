namespace GameOffer
{
    public class SpecialOfferMultyplyBase
    {
        
    }
}

/*
public class SpecialOfferMultyplyBase extends DialogOfferBase{
    public function SpecialOfferMultyplyBase() {
        super();
        addEventListener(Event.ADDED_TO_STAGE, onAdded, false, 0, true);
    }

    private var _giftsCount:int = 3;
    private var _goodGiftsCount:int = 2;

    private var openedGifts:int = 0;
    private var _vaitingTimer:Timer;
    private var openedGiftsArray:Array = [];

    private var serverCoinsCount:int = 1000000;
    protected var serverPrice:Number = 30;
    private var value:Array;

    private var finalGift:Object;

    private var tempData:Object ={"success":1,"offer":{"packages":[{"priceNew":50,"priceOld":100,"coinsNew":55000000,"coinsOld":5500000,"lpNew":7500,"lpOld":"","coinType":1,"time":83687,"actions":"buyRandomOffer","actionParams":["cms.tangelogames.com",3019,839,897,55000000,1,null,"RandomPackages"],"name":"$50 for 55M VIP=7500"},{"priceNew":50,"priceOld":100,"coinsNew":60000000,"coinsOld":0,"lpNew":7500,"lpOld":"","coinType":1,"time":83687,"actions":"buyRandomOffer","actionParams":["cms.tangelogames.com",3019,839,873,60000000,1,null,"RandomPackages"],"name":"$50 for 60,000,000 vip=7,500"},{"priceNew":50,"priceOld":100,"coinsNew":65000000,"coinsOld":0,"lpNew":7500,"lpOld":"","coinType":1,"time":83687,"actions":"buyRandomOffer","actionParams":["cms.tangelogames.com",3019,839,1148,65000000,1,null,"RandomPackages"],"name":"$50 for 65,000,000 vip=7,500 "},{"priceNew":50,"priceOld":100,"coinsNew":70000000,"coinsOld":7000000,"lpNew":7500,"lpOld":"","coinType":1,"time":83687,"actions":"buyRandomOffer","actionParams":["cms.tangelogames.com",3019,839,1043,70000000,1,null,"RandomPackages"],"name":"$50 for 70M vip=7500"}],"coupon":false,"featureID":3019,"segmentID":839}};

    protected function set giftsCount(value:int):void
    {
        _giftsCount = value;
    }

    protected function set goodGiftsCount(value:int):void
    {
        _goodGiftsCount = value;
    }

    private function onAdded(e:Event):void
    {
        removeEventListener(Event.ADDED_TO_STAGE, onAdded);
        setInfoText();
        m_mcDialog.gotoAndStop(1);
        if(m_mcDialog.total != null) {
            m_mcDialog.total.visible = false;
        }
        if(m_mcDialog.priceNew1 != null)
        {
            m_mcDialog.priceNew1.visible = false;
        }
        preinitDialog();
        setDialogData(tempData);
    }

    private function preinitDialog():void
    {
        for(var i:int = 1; i < _giftsCount + 1; i++)
        {
            m_mcDialog["btn_click_choose" + i].addEventListener(MouseEvent.CLICK, mouseClick);
            m_mcDialog["btn_click_choose" + i].addEventListener(MouseEvent.MOUSE_OVER, mouseOver);
            m_mcDialog["btn_click_choose" + i].addEventListener(MouseEvent.MOUSE_OUT, mouseOut);
        }
    }

    private function  mouseOver(event:MouseEvent):void
    {
        var clip:MovieClip = (event.currentTarget as MovieClip);
        //trace(clip.name);
        clip.gotoAndPlay(7);
    }

    private function  mouseOut(event:MouseEvent):void
    {
        var clip:MovieClip = (event.currentTarget as MovieClip);
        clip.gotoAndPlay(2);
    }

    private function  mouseClick(event:MouseEvent):void
    {
        var openedGiftValue:String = convertBigNumber(value[openedGifts]);
        var clip:MovieClip = (event.currentTarget as MovieClip);

        clip.removeEventListener(MouseEvent.CLICK, mouseClick);
        clip.removeEventListener(MouseEvent.MOUSE_OVER, mouseOver);
        clip.removeEventListener(MouseEvent.MOUSE_OUT, mouseOut);
        clip.gotoAndPlay("win");
        openedGiftsArray.push(clip.name);
        clip.coinsNew.text = openedGiftValue;

        //m_mcDialog.priceNew1.htmlText = "for only <br/> $" + finalGift.priceNew;
        //var openedGiftValue:String = "$" + convertBigNumber(finalGift.coinsNew);
        openedGifts ++;

        if(_goodGiftsCount == openedGifts)
        {
            timerForOpenWindow(openClosedGifts);
        }
    }

    private function timerForOpenWindow(callBack:Function):void
    {
        _vaitingTimer = new Timer(100, 1);
        _vaitingTimer.addEventListener("timer", callBack);
        _vaitingTimer.start();
    }

    private function openClosedGifts(event:TimerEvent):void
    {
        for(var i:int = 1; i < _giftsCount + 1; i++)
        {
            //trace("btn_click_choose" + i, m_mcDialog["btn_click_choose" + i]);
            tryToOpen(m_mcDialog["btn_click_choose" + i], "btn_click_choose" + i);
        }


        if(m_mcDialog.priceNew1 != null)
        {
            m_mcDialog.priceNew1.visible = true;
        }

        if(m_mcDialog.total != null) {
            m_mcDialog.total.visible = true;
        }
        timerForOpenWindow(showFinalScreen);
    }

    private function tryToOpen(item:MovieClip, itemName:String):void
    {
        item.removeEventListener(MouseEvent.CLICK, mouseClick);
        item.removeEventListener(MouseEvent.MOUSE_OVER, mouseOver);
        item.removeEventListener(MouseEvent.MOUSE_OUT, mouseOut);

        var isOpend:Boolean = false;
        for each(var name:String in openedGiftsArray)
        {
            if(itemName == name)
            {
                isOpend = true;
                break;
            }
        }

        if(isOpend == false)
        {
            item.gotoAndPlay("no_win");
            var openedGiftValue:String = convertBigNumberToSmall(value[openedGifts]);
            item.coinsNew.text = openedGiftValue;
            item.removeEventListener(MouseEvent.CLICK, mouseClick);
            item.play();
            openedGifts ++;
        }
    }

    private function convertBigNumberToSmall(val:String):String
    {
        var counter:int = 0;
        var comaCounter:int = 0;
        var symb:String;
        var returnValue:String = "";
        var finalSymb:String;
        var skipSymbols:int = 0;
        var putPoint:Boolean = false;

        if(val.length > 3)
        {
            finalSymb = "K";
            skipSymbols = 3;
        }
        if(val.length > 6)
        {
            finalSymb = "M";
            skipSymbols = 6;
        }

        for(var i:int = val.length - 1; i >= 0; i--)
        {
            symb = val.charAt(i);
            if(skipSymbols > counter)
            {
                if(symb != "0" || putPoint == true) {
                    returnValue = symb + returnValue;
                    putPoint = true;
                }
                counter++;
            }
            else
            {
                if(skipSymbols == counter && skipSymbols != 0)
                {
                    if(putPoint == true)
                    {
                        returnValue = "." + returnValue;
                    }
                    comaCounter = 0;
                }
                if (comaCounter >= 3)
                {
                    comaCounter = 0;
                    returnValue = "," + returnValue;
                }
                returnValue = symb + returnValue;
                counter++;
                comaCounter ++;
            }
        }
        returnValue += finalSymb;
        trace(returnValue);
        return(returnValue);
    }

    private function convertBigNumber(val:String):String
    {
        var counter:int = 0;
        var symb:String;
        var returnValue:String = "";
        var finalSymb:String;
        var skipSymbols:int = 0;
        var putPoint:Boolean = false;

        for(var i:int = val.length - 1; i >= 0; i--)
        {
            symb = val.charAt(i);

            if (counter >= 3)
            {
                counter = 0;
                returnValue = "," + returnValue;
            }
            returnValue = symb + returnValue;
            counter++;
        }
        trace(returnValue);
        return(returnValue);
    }

    override public function setDialogData(data:Object):void {
        super.setDialogData(data);
        if(m_data.offer != null && m_data.offer.coinsNew != null)
        {
            setPackage(m_data.offer);
        }
        if( m_data.offer.packages) {
            setRandomPackage(m_data.offer.packages)
        }
    }

    private function setRandomPackage(packages:Array):void
    {
        var length:int = packages.length;
        var random:int = Math.random() * length;
        if(random >= length)
        {
            random = length - 1;
        }
        var pack:Object = packages[random];

        setPackage(pack);
    }

    private function setPackage(offerPackage:Object):void
    {
        serverCoinsCount = offerPackage.coinsNew;
        if (serverCoinsCount < 10000)
            serverCoinsCount = 10000;
        finalGift = offerPackage;
        serverPrice = offerPackage.priceNew;

        setInfoText();

        if(m_mcDialog.total != null) {
            m_mcDialog.total.text = "Total " + convertBigNumber(serverCoinsCount.toString());
        }

        trace(_goodGiftsCount);
        if(_goodGiftsCount != 1) {
            value = CalculateMultiplePick.calculate(serverCoinsCount, _giftsCount, _goodGiftsCount);
        }else
        {
            value = randomiseGifts(serverCoinsCount);
        }

        trace(value);
    }

    private function randomiseGifts(serverCoinsCount:int):Array
    {
        var pack:Array =[];
        trace(serverCoinsCount);
        value = [serverCoinsCount];
        var newArray:Array = [];

        for each(var item:Object in m_data.offer.packages) {
            pack.push(item.coinsNew);
        }

        while(pack.length != 0)
        {
            var length:int = pack.length;
            var random:int = Math.random() * length;
            if(random >= length)
            {
                random = length - 1;
            }

            var packItem:String = pack[random];
            newArray = [];

            if(packItem != serverCoinsCount.toString()){
                value.push(packItem);
            }

            for each(var recreateItem:String in pack) {
                if(recreateItem != packItem){
                    newArray.push(recreateItem);
                }
            }
            pack = newArray
        }

        return value;
    }

    protected function setInfoText():void {
        if (m_mcDialog.infoText != null) {
            m_mcDialog.infoText.htmlText = "Choose 2 of the envelopes below to reveal your offer";
            m_mcDialog.priceNew1.htmlText = "for only <br/> $" + serverPrice;
        }
        else {
            m_mcDialog.priceNew1.htmlText = "Choose 2 of the kitties below to reveal your  <FONT SIZE=\"20\" COLOR=\"#ffff00\" ><b> $" + serverPrice + " </b></FONT> offer";
        }
    }

    private function showFinalScreen(event:TimerEvent):void
    {
        m_mcDialog.gotoAndStop("buy");
        m_mcDialog.btnBuy.addEventListener(MouseEvent.CLICK, onBuyClicked);
    }

    override protected function onBuyClicked(e:MouseEvent):void
    {
        buildAction();
        trace("m_action ", m_action);
        ExternalInterface.call(m_action);
        ExternalInterface.call("console.log", m_action);
        trace(m_action);
        if(finalGift)
            VIPHelper.lastPackageSelected = finalGift;
        Close();
    }

    private function buildAction():void
    {
        var pack:Object = finalGift;
        if (pack.actions != null)
        {
            m_action = pack.actions;
        }
        if (pack.actionParams != null)
        {
            m_action += "('";
            var params:String = (pack.actionParams as Array).join("','");
            m_action += params;
            m_action += "')";
        }
    }

}
}
*/