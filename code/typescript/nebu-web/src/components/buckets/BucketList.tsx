import { useGetApiBuckets } from "../../api/buckets/buckets";
import Container from "../container/Container";

const BucketList = () => {
    const bux = useGetApiBuckets();
    if (bux.isError) {
        console.error(bux.error);
    }

    return (
        <Container>
            Here are your buckets, look at them!
            <ul>
                {bux.data?.data.map(b => (
                    <li key={b.id}>{b.id}: {b.uri}</li>
                ))}
            </ul>
        </Container>
    )
}

export default BucketList;
